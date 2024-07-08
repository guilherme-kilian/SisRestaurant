import { FormEvent } from "react";
import "./CreateMenuItem.css";
import { createMenuItem } from "../../../services/sisRestaurantApi";
import { useParams } from "react-router-dom";
import { CreateMenuItemModel } from "../../../models/MenuItem/CreateMenuItemModel";
const CreateMenuItem : React.FC = () => {

    const { id } = useParams();

    async function create(form: FormEvent<HTMLFormElement>) : Promise<void>{
        form.preventDefault();

        if(!id) return;

        var data = new FormData(form.currentTarget);
        var obj = Object.fromEntries(data.entries());

        var name = obj.name.toString();
        var product = obj.product.toString();
        var price = obj.price.toString();
        var categoryName = obj.categoryName.toString();
        var picture = obj.picture.toString();

        if(!name || !product || !price || !categoryName || !picture) return;

        var create = new CreateMenuItemModel(name, product, parseFloat(price), categoryName, picture);
        await createMenuItem(parseInt(id), create)
    }    

    return <>
    <div className="menu-body">   
        <div className="menu-container">
        <h2>Adicionar Itens ao Menu</h2>
            <form id="addItemForm" onSubmit={create}>
                <div className="form-group">
                    <label htmlFor="name">Nome do Item:</label>
                    <input type="text" id="name" name="name" className="form-control" required />
                </div>
                <div className="form-group">
                    <label htmlFor="product">Produto:</label>
                    <textarea id="product" name="product" className="form-control" rows={3} required></textarea>
                </div>
                <div className="form-group">
                    <label htmlFor="price">Preço:</label>
                    <input type="number" id="price" name="price" className="form-control" step="0.01" required />
                </div>
                <div className="form-group">
                    <label htmlFor="categoryName">Categoria do item:</label>
                    <input type="text" id="categoryName" name="categoryName" className="form-control" required />
                </div>
                <div className="form-group">
                    <label htmlFor="picture">Imagem do Item:</label>
                    <input type="text" id="picture" name="picture" className="form-control" required />
                </div>
                <button type="submit" className="btn btn-primary">Adicionar Item</button>
            </form>
        </div>
    </div>
    </>
}

export default CreateMenuItem;