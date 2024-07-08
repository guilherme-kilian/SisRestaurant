import React, { useState } from "react";
import LoginModel from "../../models/LogIn/LoginModel";
import { createUser, logIn } from "../../services/sisRestaurantApi";
import CreateUserModel from "../../models/User/CreateUserModel";
import "./AccountPage.css";

const LoginPage: React.FC = () => {
  const [creatingUser, setCreatingUser] = useState<boolean>(false);
  const [email, setEmail] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [userName, setUserName] = useState<string>("");
  const [fullName, setFullName] = useState<string>("");

  async function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault();
    
    if(creatingUser){
      const createUserPayload = new CreateUserModel(fullName, userName, email, password);
      await createUser(createUserPayload);
    }
    
    const loginPayload = new LoginModel(email, password);
    await logIn(loginPayload);

    window.location.reload();
  }

  return <>
    <div className="container d-flex justify-content-center align-items-center vh-100">
          <div className="login-box">
              <h2 className="text-center">Login</h2>
              <form action="dashboard.html" method="post" onSubmit={handleSubmit}>
                  <div className="form-group">
                      <label htmlFor="email">Email:</label>
                      <input type="email" className="form-control" value={email} onChange={(event) => setEmail(() => event.target.value )} id="email" name="email" required />
                  </div>
                  <div className="form-group">
                      <label htmlFor="password">Senha:</label>
                      <input type="password" value={password} onChange={(event) => setPassword(() => event.target.value )}  className="form-control" id="password" name="password" required />
                  </div>
                  {creatingUser && 
                  <><div className="form-group">
                    <label htmlFor="email">Usuário:</label>
                      <input type="text" className="form-control" value={userName} onChange={(event) => setUserName(() => event.target.value )} />
                  </div>
                  <div className="form-group">
                    <label htmlFor="email">Nome completo:</label>
                      <input type="text" className="form-control" value={fullName} onChange={(event) => setFullName(() => event.target.value )} />
                  </div>
                  </>
                  }
                  <div className="form-group text-center">
                      <input type="submit" className="btn btn-primary" value="Entrar" />
                  </div>
                  <div className="text-center">
                    <a href="#" onClick={() => setCreatingUser(() => !creatingUser)}>{!creatingUser ? "Fazer login" : "Criar conta"}</a>
                  </div>
              </form>
          </div>
      </div>
  </>
}

export default LoginPage;
