import React from "react";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import AuthPage from "./components/Auth/AuthPage";
import LoginForm from "./components/Auth/LoginForm";
import RegisterForm from "./components/Auth/RegisterForm";
import AboutPopup from "./components/Auth/AboutPopup";
import Dash from "./components/Dash/Dashboard";

const App = () => {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<AuthPage />} />
        <Route path="/login" element={<LoginForm />} />
        <Route path="/register" element={<RegisterForm />} />
        <Route path="/about" element={<AboutPopup />} />
        <Route path="/dashboard/*" element={<Dash />} />
      </Routes>
    </Router>
  );
};

export default App;
