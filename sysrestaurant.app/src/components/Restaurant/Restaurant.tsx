import { ShortRestaurantModel } from "../../models/Restaurant/ShortRestaurantModel";

const Restaurant : React.FC<ShortRestaurantModel> = (props) => {
    return <>
            <div className="restaurant-item">
                <img src={props.picture} alt={props.name} />
                <div className="restaurant-info">
                    <h5 className="card-title">{props.name}</h5>
                    <a href="churrascaria.html" className="btn btn-primary">Ver Mais</a>
                </div>
            </div>
    </>
}

export default Restaurant;