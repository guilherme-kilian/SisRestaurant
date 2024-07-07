import { useParams } from "react-router-dom";
import Header from "../Shared/Header";
import { useEffect, useState } from "react";
import { RestaurantModel } from "../../models/Restaurant/RestaurantModel";
import { getRestaurant } from "../../services/sisRestaurantApi";
import Menu from "../Menu/Menu";
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
    }, [ id ])

    return <>
        <Header />
        <div className="container">
        <div className="restaurant-list">

            {!restaurant ? "Carregando..." : 
            restaurant.menus.map(m => 
                <Menu {...m} />
            )

            }
            <div className="restaurant-item">
                <img src="https://images.unsplash.com/photo-1544025162-d76694265947?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NHx8cmVzdGF1cmFudCUyMGZvb2QlMjBiYXJiZWN1ZXxlbnwwfHwwfHx8MA%3D%3D" alt="Entradas" />
                <div className="restaurant-info">
                    <h5 className="card-title">Entradas</h5>
                    <p className="card-text">Variedade de entradas deliciosas.</p>
                </div>
            </div>
            {/* <!-- Cardápio 2: Pratos Principais -->
            <div class="restaurant-item">
                <img src="https://images.unsplash.com/photo-1644704265419-96ddaf628e71?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTR8fHN0ZWFraG91c2V8ZW58MHx8MHx8fDA%3D">
                <div class="restaurant-info">
                    <h5 class="card-title">Pratos Principais</h5>
                    <p class="card-text">Opções de pratos principais gourmet.</p>
                </div>
            </div>
            <!-- Cardápio 3: Sobremesas -->
            <div class="restaurant-item">
                <img src="https://plus.unsplash.com/premium_photo-1672242676668-17d9d981e447?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8cmVzdGF1cmFudCUyMGRlc3NlcnR8ZW58MHx8MHx8fDA%3D" alt="Sobremesas">
                <div class="restaurant-info">
                    <h5 class="card-title">Sobremesas</h5>
                    <p class="card-text">Doces irresistíveis para finalizar sua refeição.</p>
                </div>
            </div>
            <!-- Cardápio 4: Bebidas -->
            <div class="restaurant-item">
                <img src="https://images.unsplash.com/photo-1509669803555-fd5edd8d5a41?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTV8fGNvY2t0YWlscyUyMHN0ZWFraG91c2V8ZW58MHx8MHx8fDA%3D" alt="Bebidas">
                <div class="restaurant-info">
                    <h5 class="card-title">Bebidas</h5>
                    <p class="card-text">Bebidas refrescantes e drinks especiais.</p>
                </div>
            </div> */}
        </div>
    </div>
    </>
}

export default RestaurantPage;