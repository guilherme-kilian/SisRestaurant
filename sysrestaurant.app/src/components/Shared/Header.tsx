import "./Header.css";
import { logOut } from "../../services/sisRestaurantApi";
import { useNavigate } from "react-router-dom";
const Header : React.FC = () => {

    var navigator = useNavigate();

    function signOut(){
        logOut();
        navigator('/')
        window.location.reload();
    }

    return (
    <header className="header">
        <div className="container">
            <h1 className="text-center mt-3 mb-4">Restaurantes Disponíveis</h1>
            <div className="header-links">
                <a href="#">Página Inicial</a> |
                <a href="/restaurants/create">Cadastrar Restaurante</a> |
                <a href="#" onClick={signOut}>Sair</a> 
            </div>
        </div>
    </header>)
}

export default Header;