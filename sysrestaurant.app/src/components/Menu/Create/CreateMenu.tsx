import { FormEvent } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { createMenu } from "../../../services/sisRestaurantApi";
import { CreateMenuModel } from "../../../models/Menu/CreateMenuModel";
import "./CreateMenu.css";

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
        navigator("/restaurants/" + id);
    }

    return <>
        <div className="menu-body">
            <div className="menu-container">
                <h2 className="text-center">Criação de Menu</h2>
                <form method="post" onSubmit={create}>
                    <div className="menu-form-group form-group">
                        <label htmlFor="name">Nome do menu:</label>
                        <input type="text" className="form-control" name="name" />
                    </div>
                    <div className="menu-form-group form-group text-center">
                        <input type="submit" className="btn btn-success" value="Criar" />
                    </div>
                </form>
            </div>
        </div>
    </>
}

export default CreateMenu;