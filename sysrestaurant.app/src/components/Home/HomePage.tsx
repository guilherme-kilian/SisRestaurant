import React, { useState, useEffect } from "react";
import { filterRestaurant, getUser } from "../../services/sisRestaurantApi";
import "./HomePage.css";
import Header from "../Shared/Header";
import { ShortRestaurantModel } from "../../models/Restaurant/ShortRestaurantModel";
import { FilterRestaurantModel } from "../../models/Restaurant/FilterRestaurantModel";
import Restaurant from "../Restaurant/Restaurant";

const HomePage: React.FC = () => {
  const [restaurants, setRestaurants] = useState<ShortRestaurantModel[]>();

  useEffect(() => {    
    async function fetchRestaurants(){
      let restaurants = await filterRestaurant(new FilterRestaurantModel(null, null, true));
      setRestaurants(() => restaurants);
    }
    fetchRestaurants();
  }, []);

  return <>
    <Header/>    
    <div className="container">
        { restaurants?.map((restaurant) => 
            <Restaurant {...restaurant} />
        )}
        
            {/* <div class="restaurant-item">
                <img src='https://images.unsplash.com/photo-1579871494447-9811cf80d66c?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D' alt="Sushi">
                <div class="restaurant-info">
                    <h5 class="card-title">Sushi Zen</h5>
                    <p class="card-text">Deliciosos pratos de sushi e sashimi frescos.</p>
                    <a href="sushi.html" class="btn btn-primary">Ver Mais</a>
                </div>
            </div>
            <div class="restaurant-item">
                <img src='https://images.unsplash.com/photo-1587085416963-22efba033dd5?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D' alt="Pizzaria">
                <div class="restaurant-info">
                    <h5 class="card-title">La Pizzeria</h5>
                    <p class="card-text">Pizzas artesanais com ingredientes frescos.</p>
                    <a href="pizzaria.html" class="btn btn-primary">Ver Mais</a>
                </div>
            </div>
            <div class="restaurant-item">
                <img src='https://images.unsplash.com/photo-1551782450-17144efb9c50?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTR8fGJ1cmd1ZXJ8ZW58MHx8MHx8fDA%3D' alt="Hamburgueria">
                <div class="restaurant-info">
                    <h5 class="card-title">Burger House</h5>
                    <p class="card-text">Hambúrgueres gourmet e batatas rústicas.</p>
                    <a href="hamburgueria.html" class="btn btn-primary">Ver Mais</a>
                </div>
            </div>
            <div class="restaurant-item">
                <img src='https://images.unsplash.com/photo-1571091718767-18b5b1457add?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OHx8dmVnYW4lMjBidXJndWVyfGVufDB8fDB8fHww' alt="Restaurante Vegetariano">
                <div class="restaurant-info">
                    <h5 class="card-title">Green Eats</h5>
                    <p class="card-text">Pratos vegetarianos e veganos saudáveis.</p>
                    <a href="vegetariano.html" class="btn btn-primary">Ver Mais</a>
                </div>
            </div>
            <div class="restaurant-item">
                <img src='https://plus.unsplash.com/premium_photo-1674327105074-46dd8319164b?dpr=1&w=306&auto=format&fit=crop&q=60&crop=entropy&cs=tinysrgb&fm=jpg&ixid=M3wxMjA3fDB8MXxzZWFyY2h8Nnx8Y29mZmV8cHR8MHwwfHx8MTcyMDI5MDUzNHwx&ixlib=rb-4.0.3' alt="Café">
                <div class="restaurant-info">
                    <h5 class="card-title">Café Central</h5>
                    <p class="card-text">Cafés especiais e bolos frescos.</p>
                    <a href="cafe.html" class="btn btn-primary">Ver Mais</a>
                </div>
            </div> */}
    </div>
  </> ;
}

export default HomePage;
