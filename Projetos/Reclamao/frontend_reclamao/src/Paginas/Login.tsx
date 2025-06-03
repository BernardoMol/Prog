import React from "react";
import { useNavigate } from "react-router-dom";
import "./Login.css";

const Login: React.FC = () => {
  const navigate = useNavigate();

  const handleLogin = () => {
    // Aqui você pode adicionar validação futuramente
    navigate("/usuario");
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




// import React from "react";
// import { Card, CardContent } from "@/components/ui/card";
// import { Button } from "@/components/ui/button";
// import { Input } from "@/components/ui/input";

// const LoginPage: React.FC = () => {
//   return (
//     <div className="min-h-screen flex items-center justify-center bg-gray-100">
//       <Card className="w-full max-w-sm p-6 shadow-lg">
//         <CardContent className="flex flex-col space-y-4">
//           <h2 className="text-2xl font-bold text-center">Login</h2>
//           <Input type="text" placeholder="Login" className="w-full" />
//           <Input type="password" placeholder="Senha" className="w-full" />
//           <Button className="w-full">Conectar</Button>
//           <a
//             href="#"
//             className="text-sm text-center text-blue-600 hover:underline"
//           >
//             Esqueceu sua senha?
//           </a>
//         </CardContent>
//       </Card>
//     </div>
//   );
// };

// export default LoginPage;
// export {};