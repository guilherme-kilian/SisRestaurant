import { BrowserRouter, Routes, Route } from "react-router-dom";
import './App.css';
import LoginPage from "./components/Account/AccountPage";
import HomePage from "./components/Home/HomePage";
import RequireAuth from "./components/Shared/RequireAuth";
import RestaurantPage from "./components/Restaurant/RestaurantPage";

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
            <RestaurantPage  />
          </RequireAuth>
        } /> 
      </Routes>
    </BrowserRouter>
  );
}