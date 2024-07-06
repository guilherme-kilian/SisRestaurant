import { BrowserRouter, Routes, Route } from "react-router-dom";
import './App.css';
import LoginPage from "./components/AccountPage";
import HomePage from "./components/HomePage";
import RequireAuth from "./components/Shared/RequireAuth";

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
      </Routes>
    </BrowserRouter>
  );
}