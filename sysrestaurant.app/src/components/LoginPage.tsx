import React, { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import LoginModel from "../models/LoginModel";

const LoginPage: React.FC = () => {
  const navigate = useNavigate();

  const [email, setUserName] = useState<string>("");
  const [password, setPassword] = useState<string>("");

  function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault();

    const loginPayload = new LoginModel(email, password);
    
    axios
      .post("https://localhost:7000/api/v1/authentication", loginPayload)
      .then((response) => {
        const token = response.data.authorizationToken;

        localStorage.setItem("token", token);

        if (token) {
          axios.defaults.headers.common["Authorization"] = `Bearer ${token}`;
        }

        navigate("/");
      })
      .catch((err) => console.log(err));
  }

  function handleUserNameChange(event: React.ChangeEvent<HTMLInputElement>) {
    setUserName(() => event.target.value );
  }

  function handlePasswordhange(event: React.ChangeEvent<HTMLInputElement>) {
    setPassword(() => event.target.value);
  }

  return (
    <form onSubmit={handleSubmit}>
      <div className="d-flex flex-column justify-content-center align-items-center">
          <label>
            Email:
            <input type="text" className="form-control" value={email} onChange={handleUserNameChange} />
          </label>
          <label>
            Password:
            <input type="text" className="form-control" value={password} onChange={handlePasswordhange} />
          </label>
          <input type="submit" className="btn btn-primary" value="Login" />
      </div>
    </form>
  );
}

export default LoginPage;
