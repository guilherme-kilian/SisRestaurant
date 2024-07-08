import { FormEvent, useState } from "react";
import { CreateReservationModel } from "../../models/Reservation/CreateReservationModel";
import "./ReservationPage.css";
import { useNavigate, useParams } from "react-router-dom";
import { createReservation } from "../../services/sisRestaurantApi";
import ReservationSuccess from "./ReservationSuccess";
const ReservationPage : React.FC = () => {

    const { id } = useParams();
    const [success, setSuccess] = useState<boolean>(false);

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
        setSuccess(() => true);
    }

    return <>
    {success 
        ? <ReservationSuccess /> 
        : <div className="reservation-body">
            <div className="reservation-container">
            <h2 className="text-center">Reserva de Restaurante</h2>
            <form action="confirmacao.html" method="post" onSubmit={create}>
                <div className="form-group">
                    <label htmlFor="date">Data da Reserva:</label>
                    <input type="datetime-local" className="form-control" id="date" name="date" required />
                </div>
                <div className="form-group">
                    <label htmlFor="count">Número de Pessoas:</label>
                    <input type="number" className="form-control" id="count" name="count" required />
                </div>
                <div className="form-group">
                    <label htmlFor="details">Detalhes:</label>
                    <input type="tel" className="form-control" id="details" name="details" required />
                </div>
                <div className="form-group text-center">
                    <input type="submit" className="btn btn-success" value="Realizar Reserva" />
                </div>
                </form>
            </div>
        </div>
    }
    </>
}

export default ReservationPage;

