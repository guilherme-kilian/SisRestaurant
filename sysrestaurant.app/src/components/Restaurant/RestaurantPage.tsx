import { useNavigate, useParams } from "react-router-dom";
import Header from "../Shared/Header";
import { useEffect, useState } from "react";
import { RestaurantModel } from "../../models/Restaurant/RestaurantModel";
import { getRestaurant, getUser } from "../../services/sisRestaurantApi";
import Menu from "../Menu/Menu";
import HeaderRestaurant from "../Shared/HeaderRestaurant";
const RestaurantPage : React.FC = () => {

    const [ restaurant, setRestaurant ] = useState<RestaurantModel>();
    const { id } = useParams()
    const [owner, setOwner] = useState<boolean>(false);
    var navigator = useNavigate();

    if(!id){
        throw new Error("Id is required");
    }

    function redirectToCreateMenuItem(menuId: number){
        navigator(`/restaurants/${restaurant?.id}/menu/${menuId}/menuitem/create`);
    }

    useEffect(() => {
        async function fetchRestaurant(){
            if(!id) return;

            let restaurant = await getRestaurant(parseInt(id));
            setRestaurant(() => restaurant);

            var user = await getUser();

            if(restaurant.users.find(u => u.id === user.id)){
                setOwner(() => true)
            }
        }

        fetchRestaurant();
    }, [ id ])

    return <>
    <div className="body-3-restaurantes">
        { !restaurant ? "Carregando..." : 
            <HeaderRestaurant restaurantId={restaurant.id} restaurantName={restaurant.name}/>
        }        
        <div className="container-3-restaurantes">
            <div className="restaurant-list-3-restaurantes">
                {!restaurant ? "Carregando..." : 
                    restaurant.menus.map(m => <Menu menu={m} owner={owner} redirectCreateMenuItem={redirectToCreateMenuItem} />)
                }
            </div>
        </div>
    </div>
    </>
}

export default RestaurantPage;