import { useNavigate } from "react-router-dom";
import "./HeaderRestaurant.css";
import { logOut } from "../../services/sisRestaurantApi";

const HeaderRestaurant : React.FC<{ restaurantName: string, restaurantId: number}> = (props) => {

    var navigator = useNavigate();

    function signOut(){
        logOut();
        navigator('/')
        window.location.reload();
    }

    return <>
        <header className="header-3-restaurantes">
            <div className="container-3-restaurantes">
                <h1 className="text-center mt-3 mb-4">{props.restaurantName}</h1>
                <div className="header-links-3-restaurantes">
                    <a href="/">Página Inicial</a> |
                    <a href={`/restaurants/${props.restaurantId}/reservation`}>Realizar Reserva</a> |
                    <a href="#" onClick={signOut}>Sair</a>
                </div>
            </div>
        </header>
    </>
}

export default HeaderRestaurant;