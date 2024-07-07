import "./ReservationPage.css";

const ReservationPage : React.FC = () => {
    return <>
        <div className="container">
        <h2 className="text-center">Reserva de Restaurante</h2>
        <form action="confirmacao.html" method="post">
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
            <div className="form-group">
                <label htmlFor="name">Nome:</label>
                <input type="text" className="form-control" id="name" name="name" required />
            </div>
            <div className="form-group">
                <label htmlFor="cpf">CPF:</label>
                <input type="text" className="form-control" id="cpf" name="cpf" required />
            </div>
            <div className="form-group text-center">
                <input type="submit" className="btn btn-success" value="Enviar Reserva" />
            </div>
        </form>
    </div>
    </>
}

export default ReservationPage;

