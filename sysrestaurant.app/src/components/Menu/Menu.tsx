import { MenuModel } from "../../models/Menu/MenuModel";
import MenuItem from "../MenuItem/MenuItem";
import "./Menu.css";

const Menu : React.FC<{ menu: MenuModel, owner: boolean, redirectCreateMenuItem: (menuId: number) => void }> = (props) => {
    return <>
        <div className="card d-flex flex-column">    
            <div className="card-header">
                <div>{props.menu.name}</div>
            </div>
            <div className="card-body">
                {props.menu.items.map(mi => <MenuItem {...mi} /> )}
            </div>
            <div className="card-footer">
                {props.owner 
                    ? 
                        <button className="btn btn-primary" onClick={() => props.redirectCreateMenuItem(props.menu.id)}>Adicionar item</button> 
                    : ""}
            </div>
        </div>
    </>
}

export default Menu;