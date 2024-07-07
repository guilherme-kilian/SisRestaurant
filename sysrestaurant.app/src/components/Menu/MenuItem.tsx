import { MenuItemModel } from "../../models/MenuItem/MenuItemModel";

const MenuItem : React.FC<MenuItemModel> = (props) => {
    return <>
    <div className="restaurant-item">
        {props.picture ? 
            <img src={props.picture} alt="Entradas" />
        : ""}                    
        <div className="restaurant-info">
            <h5 className="card-title">{props.name}</h5>
            <p className="card-text">{props.description}</p>
        </div>
    </div></>
}

export default MenuItem;