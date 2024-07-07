import { FormEvent } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { createMenu } from "../../../services/sisRestaurantApi";
import { CreateMenuModel } from "../../../models/Menu/CreateMenuModel";
const CreateMenu : React.FC = () => {

    const { id } = useParams();
    var navigator = useNavigate();

    async function create(form: FormEvent<HTMLFormElement>) : Promise<void>{
        form.preventDefault();
        if(!id) return;
        var data = new FormData(form.currentTarget);
        var obj = Object.fromEntries(data.entries());

        var create = new CreateMenuModel(obj.name.toString(), parseInt(id), null);
        await createMenu(create);
        navigator("/restaurant/" + id);
    }

    return <>
        
    </>
}

export default CreateMenu;