import "./Header.css";

const Header : React.FC = () => {
    return (
    <header className="header">
        <div className="container">
            <h1 className="text-center mt-3 mb-4">Restaurantes Disponíveis</h1>
            <div className="header-links">
                <a href="#">Página Inicial</a> |
                <a href="/restaurants/create">Cadastrar Restaurante</a>
            </div>
        </div>
    </header>)
}

export default Header;