import { BrowserRouter, Routes, Route } from "react-router-dom";
import './App.css';
import LoginPage from "./components/Account/AccountPage";
import HomePage from "./components/Home/HomePage";
import RequireAuth from "./components/Shared/RequireAuth";
import RestaurantPage from "./components/Restaurant/RestaurantPage";
import ReservationPage from "./components/Reservation/ReservationPage";
import CreateRestaurantPage from "./components/Restaurant/Create/CreateRestaurantPage";
import CreateMenuItem from "./components/MenuItem/Create/CreateMenuItem";
import CreateMenu from "./components/Menu/Create/CreateMenu";

export default function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/login" element={<LoginPage />} />        
        <Route path="/" element={
          <RequireAuth>
            <HomePage />
          </RequireAuth>
        } /> 
        <Route path="/restaurants/:id" element={
          <RequireAuth>
            <RestaurantPage  />
          </RequireAuth>
        } /> 
        <Route path="/restaurants/:id/reservation" element={
          <RequireAuth>
            <ReservationPage  />
          </RequireAuth>
        } /> 
        <Route path="/restaurants/create" element={
          <RequireAuth>
            <CreateRestaurantPage  />
          </RequireAuth>
        } />
        <Route path="/restaurants/:id/menu/create" element={
          <RequireAuth>
            <CreateMenu  />
          </RequireAuth>
        } />  
        <Route path="/restaurants/:restaurantId/menu/:id/menuitem/create" element={
          <RequireAuth>
            <CreateMenuItem  />
          </RequireAuth>
        } />  
      </Routes>
    </BrowserRouter>
  );
}