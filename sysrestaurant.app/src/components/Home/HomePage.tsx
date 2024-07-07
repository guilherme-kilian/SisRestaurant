import React, { useState, useEffect } from "react";
import { filterRestaurant, getUser } from "../../services/sisRestaurantApi";
import "./HomePage.css";
import Header from "../Shared/Header";
import { ShortRestaurantModel } from "../../models/Restaurant/ShortRestaurantModel";
import { FilterRestaurantModel } from "../../models/Restaurant/FilterRestaurantModel";
import Restaurant from "../Restaurant/Restaurant";
import { useNavigate } from "react-router-dom";

const HomePage: React.FC = () => {
    const [restaurants, setRestaurants] = useState<ShortRestaurantModel[]>();
    const navigator = useNavigate();

    function redirectToRestaurant(id: number){
        navigator('/restaurants/' + id);
    }

    useEffect(() => {    
        async function fetchRestaurants() {
            let restaurants = await filterRestaurant(new FilterRestaurantModel(null, null, true));
            setRestaurants(() => restaurants);
        }
        
        fetchRestaurants();
    }, []);

  return <>
    <Header/>    
    <div className="container">
        { restaurants?.map((restaurant) => 
            <Restaurant item={restaurant} click={redirectToRestaurant} />
        )}
    </div>
  </> ;
}

export default HomePage;
