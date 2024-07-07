import { useParams } from "react-router-dom";
import Header from "../Shared/Header";
import { useEffect, useState } from "react";
import { RestaurantModel } from "../../models/Restaurant/RestaurantModel";
import { getRestaurant } from "../../services/sisRestaurantApi";
import Menu from "../Menu/Menu";
import HeaderRestaurant from "../Shared/HeaderRestaurant";
const RestaurantPage : React.FC = () => {

    const [ restaurant, setRestaurant ] = useState<RestaurantModel>();
    const { id } = useParams()

    if(!id){
        throw new Error("Id is required");
    }

    useEffect(() => {
        async function fetchRestaurant(){
            if(!id) return;

            let restaurant = await getRestaurant(parseInt(id));
            setRestaurant(() => restaurant);
        }

        fetchRestaurant();
    }, [ id ])

    return <>

        { !restaurant ? "Carregando..." : 
            <HeaderRestaurant restaurantName={restaurant.name}/>
        }        
        <div className="container">
        <div className="restaurant-list">

            {!restaurant ? "Carregando..." : 
                restaurant.menus.map(m => <Menu {...m} />)
            }
        </div>
    </div>
    </>
}

export default RestaurantPage;