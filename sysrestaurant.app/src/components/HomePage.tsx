import React, { useState, useEffect } from "react";
import { UserModel } from "../models/User/UserModel";
import { getUser } from "../services/sisRestaurantApi";

const HomePage: React.FC = () => {
  const [data, setData] = useState<UserModel>();

  useEffect(() => {
    
    async function fetchUser(){
      let user = await getUser();
      setData(() => user);
    }

    if (data === undefined || data === null) {
      fetchUser();
    }
  });

  return <div>{data?.email}</div>;
}

export default HomePage;
