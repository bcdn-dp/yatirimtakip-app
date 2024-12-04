import React, { useState } from "react";
import "./styles/AuthPage.css";
import LoginForm from "./LoginForm";
import RegisterForm from "./RegisterForm";
import AboutPopup from "./AboutPopup";

const AuthPage = () => {
  const [showLogin, setShowLogin] = useState(false);
  const [showRegister, setShowRegister] = useState(false);
  const [showAbout, setShowAbout] = useState(false);

  return (
    <div className="auth-container">
      <div className="auth-title-box">
        <h1 className="auth-title">Yatirim Takip</h1>
      </div>
      <div className="auth-button-container">
        <button className="auth-button" onClick={() => setShowLogin(true)}>
          Login
        </button>
        <button className="auth-button" onClick={() => setShowRegister(true)}>
          Register
        </button>
      </div>
      <div className="auth-about-container">
        <button
          className="auth-about-button"
          onClick={() => setShowAbout(true)}
        >
          About
        </button>
      </div>
      {showLogin && <LoginForm onClose={() => setShowLogin(false)} />}
      {showRegister && <RegisterForm onClose={() => setShowRegister(false)} />}
      {showAbout && <AboutPopup onClose={() => setShowAbout(false)} />}
    </div>
  );
};

export default AuthPage;
