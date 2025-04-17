using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Diagnostics; // Adicionado para Process e ProcessStartInfo

namespace ScreenSound.BANCO
{
    public class MigracaoAutomatizada
    {
        public void GerarMigracao()
        {
            try
            {
                if (HaAlteracoesNoModelo())
                {
                    string nomeMigracao = $"AutoMigration_{DateTime.Now:yyyyMMdd_HHmmss}";
                    ExecutarComando($"dotnet ef migrations add {nomeMigracao}");
                    Console.WriteLine($"Migração '{nomeMigracao}' gerada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Nenhuma alteração detectada no modelo. Nenhuma migração foi gerada.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao gerar a migração: {ex.Message}");
            }
        }

        private bool HaAlteracoesNoModelo()
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = "ef migrations add Teste --dry-run", // Simula a criação de uma migração
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = new Process { StartInfo = psi })
                {
                    process.Start();
                    string saida = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    return !saida.Contains("No changes were found"); // Retorna TRUE se houver alterações
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao verificar mudanças no modelo: {ex.Message}");
                return false;
            }
        }

        private void ExecutarComando(string comando)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/C {comando}",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = new Process { StartInfo = psi })
                {
                    process.Start();
                    string saida = process.StandardOutput.ReadToEnd();
                    string erro = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    Console.WriteLine($"Saída: {saida}");
                    if (!string.IsNullOrEmpty(erro))
                        Console.WriteLine($"Erro: {erro}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao executar comando: {ex.Message}");
            }
        }
    }
}