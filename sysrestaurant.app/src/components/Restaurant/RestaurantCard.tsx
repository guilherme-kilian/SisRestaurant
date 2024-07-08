import { ShortRestaurantModel } from "../../models/Restaurant/ShortRestaurantModel";
import "./RestaurantCard.css";

const RestaurantCard : React.FC<{ item: ShortRestaurantModel, click: (id: number) => void }> = (props) => {
    return <>
            <div className="restaurant-item mx-2">
                <img src={props.item.picture} alt={props.item.name} />
                <div className="restaurant-info">
                    <h5 className="card-title">{props.item.name}</h5>
                    <p className="card-text">{props.item.description}</p>
                    <a href="#" onClick={() => props.click(props.item.id)} className="btn btn-primary">Ver Mais</a>
                </div>
            </div>
    </>
}

export default RestaurantCard;