import { FC } from "react";
import { isAuthenticated } from "../../services/sisRestaurantApi";
import LoginPage from "../AccountPage";

const RequireAuth: FC<{ children: React.ReactElement }> = ({ children }) => {
    const userIsLogged = isAuthenticated();
    
    if (!userIsLogged) {
       return <LoginPage />;
    }
    
    return children;
 };

 export default RequireAuth