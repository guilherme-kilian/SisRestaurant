import axios from "axios";
import React, { useState, useEffect } from "react";
import UserModel from "../models/UserModel";

const HomePage: React.FC = () => {
  const [data, setData] = useState<UserModel>();

  useEffect(() => {
    const token = localStorage.getItem("token");

    if (token) {
      axios.defaults.headers.common["Authorization"] = `Bearer ${token}`;
    }

    if (data === undefined || data === null) {
      axios
        .get("https://localhost:7000/api/v1/user")
        .then((response) => {
          const data = response.data;
          setData(() => new UserModel(data.id, data.email, data.userName, data.name));
        })
        .catch((err) => console.log(err));
    }
  });

  return <div>Home Page {data?.email}</div>;
}

export default HomePage;
