import "./HeaderRestaurant.css";

const HeaderRestaurant : React.FC<{ restaurantName: string}> = (props) => {
    return <>
        <header className="header">
            <div className="container">
                <h1 className="text-center mt-3 mb-4">{props.restaurantName}</h1>
                <div className="header-links">
                    <a href="#">Página Inicial</a> |
                    <a href="#">Login</a> |
                    <a href="#">Realizar Reserva</a>
                </div>
            </div>
        </header>
    </>
}

export default HeaderRestaurant;