// src/App.js

import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Home from './components/Home';
import Restaurantes from './components/Restaurantes';
import Login from './components/Login';
import Sistema from "./components/Sistema";

const App = () => {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/restaurantes" element={<Restaurantes />} />
                <Route path="/login" element={<Login />} />
                <Route path="/sistema" element={<Sistema />} />
            </Routes>
        </Router>
    );
};

export default App;
