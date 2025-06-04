import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom'; // <--- ADICIONE ESTA LINHA
import './Registrar.css'; // Importa o arquivo CSS

const Registrar: React.FC = () => {
  const [email, setEmail] = useState('');
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [error, setError] = useState('');
  const [success, setSuccess] = useState('');

  const navigate = useNavigate();

  const handleSubmit = (event: React.FormEvent) => {
    event.preventDefault(); // Previne o comportamento padrão de recarregar a página

    setError(''); // Limpa mensagens de erro anteriores
    setSuccess(''); // Limpa mensagens de sucesso anteriores

    if (!email || !username || !password || !confirmPassword) {
      setError('Todos os campos são obrigatórios.');
      return;
    }

    if (password !== confirmPassword) {
      setError('A senha e a confirmação de senha não coincidem.');
      return;
    }

    // Aqui você faria a lógica de envio para um backend
    // Por exemplo:
    console.log('Dados de registro:', { email, username, password });

    setSuccess('Registro realizado com sucesso!');

    // Simulação de uma chamada de API bem-sucedida
    setTimeout(() => {
      setEmail('');
      setUsername('');
      setPassword('');
      setConfirmPassword('');
      // Redireciona para a página de login após o tempo
      navigate('/'); // Assumindo que sua página de login está na rota '/
    }, 2000); // Redireciona após 3 segundos (3000 milissegundos)

  };

  return (
    <div className="register-container">
      <form onSubmit={handleSubmit} className="register-form">
        <h2>Criar Conta</h2>
        {error && <p className="error-message">{error}</p>}
        {success && <p className="success-message">{success}</p>}

        <div className="form-group">
          <label htmlFor="email">Email:</label>
          <input
            type="email"
            id="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="username">Nome de Usuário:</label>
          <input
            type="text"
            id="username"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="password">Senha:</label>
          <input
            type="password"
            id="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="confirmPassword">Confirmar Senha:</label>
          <input
            type="password"
            id="confirmPassword"
            value={confirmPassword}
            onChange={(e) => setConfirmPassword(e.target.value)}
            required
          />
        </div>

        <button type="submit" className="register-button">Registrar</button>
      </form>
    </div>
  );
};

export default Registrar;