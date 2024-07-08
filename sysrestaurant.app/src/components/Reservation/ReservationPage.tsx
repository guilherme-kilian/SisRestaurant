import { FormEvent } from "react";
import { CreateReservationModel } from "../../models/Reservation/CreateReservationModel";
import "./ReservationPage.css";
import { useParams } from "react-router-dom";
import { createReservation } from "../../services/sisRestaurantApi";
const ReservationPage : React.FC = () => {

    const { id } = useParams();

    if(!id){
        throw new Error("ID não informado");
    }       

    async function create(form: FormEvent<HTMLFormElement>) : Promise<void>{
        form.preventDefault();

        var data = new FormData(form.currentTarget);

        var obj = Object.fromEntries(data.entries());

        var date = obj.date.toString();
        var count = obj.count.toString();
        var details = obj.details.toString();

        if(!date || !count || !details) return;

        if(!id) return;

        var realDate = new Date(date);

        var create = new CreateReservationModel(parseInt(id), realDate!, parseInt(count!), details!,)
        await createReservation(create);
    }

    return <>
    <div className="reservation-body">
        <div className="reservation-container">
        <h2 className="text-center">Reserva de Restaurante</h2>
        <form action="confirmacao.html" method="post" onSubmit={create}>
            <div className="form-group">
                <label htmlFor="date">Data da Reserva:</label>
                <input type="date" className="form-control" id="date" name="date" required />
            </div>
            <div className="form-group">
                <label htmlFor="number-of-people">Número de Pessoas:</label>
                <input type="number" className="form-control" id="number-of-people" name="number-of-people" required />
            </div>
            <div className="form-group">
                <label htmlFor="phone">Telefone:</label>
                <input type="tel" className="form-control" id="phone" name="phone" required />
            </div>
            <div className="form-group text-center">
                <input type="submit" className="btn btn-success" value="Enviar Reserva" />
            </div>
            </form>
        </div>
    </div>
    </>
}

export default ReservationPage;

