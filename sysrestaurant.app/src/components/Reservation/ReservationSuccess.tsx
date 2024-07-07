import { useNavigate  } from "react-router-dom";

const ReservationSuccess : React.FC = () => {
    var navigator = useNavigate();

    function goHome(){
        navigator("/");
    }

    return <>
        <div className="container">
            <h2>Reserva Confirmada!</h2>
            <p>Obrigado por reservar conosco. Sua reserva foi confirmada com sucesso.</p>
            <p>Enviaremos um lembrete um dia antes da sua reserva.</p>
            <a href="index.html" className="btn" onClick={goHome}>Voltar para o Início</a>
        </div>
    </>
}

export default ReservationSuccess;