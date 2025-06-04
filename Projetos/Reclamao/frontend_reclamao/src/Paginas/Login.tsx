import React from "react";
import { useNavigate } from "react-router-dom";
import "./Login.css";

const Login: React.FC = () => {
  const navigate = useNavigate();

  const handleLogin = () => {
    // Aqui você pode adicionar validação futuramente
    navigate("/usuario"); // Redireciona para a página de usuário após o login
  };

  const handleRegister = () => {
    navigate("/registrar"); // Redireciona para a página de registro
  };

  return (
    <div className="login-container">
      <div className="welcome-banner">Bem Vindo ao Reclamão!</div>
      <div className="login-box">
        <h2 className="login-title">Login</h2>
        <input type="text" placeholder="Login" className="login-input" />
        <input type="password" placeholder="Senha" className="login-input" />
        <button onClick={handleLogin} className="login-button">
          Entrar
        </button>
        {/* Novo botão de Registro */}
        <button onClick={handleRegister} className="register-button">
          Registrar
        </button>
        <p className="login-forgot">
          <a href="#" className="login-link">
            Esqueceu sua senha?
          </a>
        </p>
      </div>
    </div>
  );
};

export default Login;