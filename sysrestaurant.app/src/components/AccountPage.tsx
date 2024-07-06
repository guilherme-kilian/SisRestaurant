import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import LoginModel from "../models/LogIn/LoginModel";
import { createUser, logIn } from "../services/sisRestaurantApi";
import CreateUserModel from "../models/User/CreateUserModel";

const LoginPage: React.FC = () => {
  const navigate = useNavigate();
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

  return (
    <form onSubmit={handleSubmit}>      
      <div className="d-flex flex-column justify-content-center align-items-center">
        {creatingUser && 
        <><div className="form-group">
          <label>
            Nome de usuário:
            <input type="text" className="form-control" value={userName} onChange={(event) => setUserName(() => event.target.value )} />
          </label>
        </div>
        <div className="form-group">
          <label>
            Nome completo:
            <input type="text" className="form-control" value={fullName} onChange={(event) => setFullName(() => event.target.value )} />
          </label>
        </div>
        </>
        }
        <div className="form-group">
          <label>
            Email:
            <input type="text" className="form-control" value={email} onChange={(event) => setEmail(() => event.target.value )} />
          </label>
        </div>
        <div className="form-group">
          <label>
            Password:
            <input type="password" className="form-control" value={password} onChange={(event) => setPassword(() => event.target.value )} />
          </label>
        </div>
        <input type="submit" className="btn btn-primary" value="Login" />
        <a href="#" onClick={() => setCreatingUser(() => !creatingUser)}>{creatingUser ? "Fazer login" : "Criar conta"}</a>
      </div>
    </form>
  );
}

export default LoginPage;
