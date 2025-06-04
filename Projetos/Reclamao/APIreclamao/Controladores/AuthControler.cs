using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using bibliotecaReclamao.Banco.Conexao;
using bibliotecaReclamao.Banco.DTOs;
using bibliotecaReclamao.Banco.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace APIreclamao.Controladores
{
    [ApiController]
    [Route("[controller]")]
    public class AuthControler : ControllerBase
    {
        private readonly ConexaoContexto _context;
        private readonly IConfiguration _configuration; // Para acessar as configurações do JWT
        public AuthControler(ConexaoContexto context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<Usuario>> Register([FromBody] RegistroDeUsuarioDTO novoRegistro)
        {
            // 1. Validar entrada (opcional, mas recomendado: usar Data Annotations ou FluentValidation)
            if (string.IsNullOrWhiteSpace(novoRegistro.NomeUsuario) || string.IsNullOrWhiteSpace(novoRegistro.EmailUsuario) || string.IsNullOrWhiteSpace(novoRegistro.SenhaUsuario))
            {
                return BadRequest("Nome de usuário, e-mail e senha são obrigatórios.");
            }

            // 2. Verificar se o usuário/email já existe no banco
            if (await _context.Usuarios.AnyAsync(u => u.EmailUsuario == novoRegistro.EmailUsuario || u.NomeUsuario == novoRegistro.NomeUsuario))
            {
                return Conflict("Nome de usuário ou e-mail já registrado.");
            }

            // 3. Gerar o hash da senha
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(novoRegistro.SenhaUsuario); // Use o BCrypt.Net.Core

            // 4. Criar a nova instância do seu modelo Usuario
            var novoUsuario = new Usuario
            {
                NomeUsuario = novoRegistro.NomeUsuario,
                EmailUsuario = novoRegistro.EmailUsuario,
                SenhaUsuario = passwordHash, // Salva o hash da senha, NÃO a senha em texto claro
                // Adicione outras propriedades padrão que seu Usuario possa ter, ex: DataCriacao = DateTime.Now;
            };

            // 5. Salvar no banco de dados
            _context.Usuarios.Add(novoUsuario);
            await _context.SaveChangesAsync();
            return Ok(novoRegistro);
        }


        // Endpoint de Login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO request) // Recebe o DTO de login
        {
            // 1. Encontrar o usuário pelo nome de usuário ou e-mail
            // Adapte conforme seu campo de login principal (NomeUsuario ou EmailUsuario)
            var usuario = await _context.Usuarios
                                        .FirstOrDefaultAsync(u => u.NomeUsuario == request.NomeUsuario || u.EmailUsuario == request.NomeUsuario);

            if (usuario == null)
            {
                return Unauthorized("Credenciais inválidas."); // Não diga se é usuário ou senha para não dar dica a atacantes
            }

            // 2. Verificar a senha: compare a senha fornecida com o hash armazenado
            if (!BCrypt.Net.BCrypt.Verify(request.SenhaUsuario, usuario.SenhaUsuario)) // Use BCrypt.Net.Core
            {
                return Unauthorized("Credenciais inválidas.");
            }

            // 3. Se credenciais válidas, gerar o JWT
            var token = GerarJwtToken(usuario);

            // 4. Retornar o token
            return Ok(new Token { TokenGerado = token });
        }
        
                // Método auxiliar para gerar o JWT
        private string GerarJwtToken(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.UsuarioId.ToString()), // Id do usuário
                new Claim(ClaimTypes.Name, usuario.NomeUsuario), // Nome de usuário
                new Claim(ClaimTypes.Email, usuario.EmailUsuario) // Email do usuário
                // Adicione outras claims importantes aqui, como roles (cargos) se tiver
            };

            var jwtKey = _configuration["Jwt:Key"];
            var jwtIssuer = _configuration["Jwt:Issuer"];
            var jwtAudience = _configuration["Jwt:Audience"];
            var jwtExpireDays = Convert.ToDouble(_configuration["Jwt:ExpireDays"]);

            // Validações básicas das configurações
            if (string.IsNullOrEmpty(jwtKey) || string.IsNullOrEmpty(jwtIssuer) || string.IsNullOrEmpty(jwtAudience) || jwtExpireDays <= 0)
            {
                throw new InvalidOperationException("Configurações JWT inválidas ou incompletas no appsettings.json.");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(jwtExpireDays);

            var token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtAudience,
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}