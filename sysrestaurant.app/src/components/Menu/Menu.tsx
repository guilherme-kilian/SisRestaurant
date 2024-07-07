import { MenuModel } from "../../models/Menu/MenuModel";
import MenuItem from "./MenuItem";

const Menu : React.FC<MenuModel> = (props) => {
    return <div>{props.items.map(mi => <MenuItem {...mi} /> )}</div>
}

export default Menu;