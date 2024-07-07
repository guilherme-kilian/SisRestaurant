import { MenuModel } from "../../models/Menu/MenuModel";
import MenuItem from "../MenuItem/MenuItem";

const Menu : React.FC<{ menu: MenuModel, owner: boolean, redirectCreateMenuItem: (menuId: number) => void }> = (props) => {
    return <div>
            <div>{props.menu.name}</div>
            {props.menu.items.map(mi => <MenuItem {...mi} /> )}
            {props.owner 
                ? 
                    <button onClick={() => props.redirectCreateMenuItem(props.menu.id)}>Adicionar item</button> 
                : ""}
        </div>
}

export default Menu;