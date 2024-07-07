import { FormEvent } from "react";
import "./CreateRestaurantPage.css";
import { CreateReservationSettingsModel, CreateRestaurantModel } from "../../../models/Restaurant/CreateRestaurantModel";
import { createRestaurant } from "../../../services/sisRestaurantApi";
const CreateRestaurantPage : React.FC = () => {

    async function handleSubmit(event: FormEvent<HTMLFormElement>){
        event.preventDefault();
        var data = new FormData(event.currentTarget);
        var obj = Object.fromEntries(data.entries());
        var settings = new CreateReservationSettingsModel(false, parseInt( obj.capacity.toString()), obj.startAt.toString(), obj.finishAt.toString());
        var restaurant = new CreateRestaurantModel(obj.name.toString(), obj.phoneNumber.toString(), obj.email.toString(), settings, obj.picture.toString(), obj.details.toString());
        await createRestaurant(restaurant);
    }

    return <>
            <div className="container">
                <h1>Cadastro de Restaurante</h1>
                <form action="/processar-cadastro" method="post" onSubmit={handleSubmit}>
                    <label htmlFor="nome">Nome do Restaurante:</label>
                    <input type="text" id="nome" name="nome" required />

                    <label htmlFor="phoneNumber">Telefone:</label>
                    <input type="text" id="phoneNumber" name="phoneNumber" required />

                    <label htmlFor="email">E-mail:</label>
                    <input type="text" id="email" name="email" required />

                    <label htmlFor="details">Detalhes:</label>
                    <input type="text" id="details" name="details" required />

                    <label htmlFor="picture">Foto:</label>
                    <input type="text" id="picture" name="picture" required />

                    <label htmlFor="capacity">Capacidade total:</label>
                    <input id="number" name="capacity" required />

                    <label htmlFor="startAt">Inicia as:</label>
                    <input type="time" id="startAt" name="startAt" required />

                    <label htmlFor="finishAt">Finaliza as:</label>
                    <input type="time" id="finishAt" name="finishAt" required />

                    <button type="submit">Cadastrar Restaurante</button>
                </form>
            </div>
        </>
}

export default CreateRestaurantPage;