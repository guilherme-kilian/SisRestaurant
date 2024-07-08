import { useNavigate  } from "react-router-dom";

const ReservationSuccess : React.FC = () => {
    var navigator = useNavigate();

    function goHome(){
        navigator("/");
    }

    return <>
    <div className="body-4-reserva">
        <div className="container-4-reserva">
            <h2 className="h2-4-reserva">Reserva Confirmada!</h2>
            <p className="p-4-reserva">Obrigado por reservar conosco. Sua reserva foi confirmada com sucesso.</p>
            <p className="p-4-reserva">Enviaremos um lembrete um dia antes da sua reserva.</p>
            <a href="#" className="btn btn-4-reserva" onClick={goHome}>Voltar para o Início</a>
        </div>
    </div>
    </>
}

export default ReservationSuccess;