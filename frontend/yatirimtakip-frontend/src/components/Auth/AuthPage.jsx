import React from "react";
import { Link } from "react-router-dom";
import "./styles/AuthPage.css";

const AuthPage = () => {
  return (
    <div className="auth-container">
      <div className="auth-title-box">
        <h1 className="auth-title">Yatirim Takip</h1>
      </div>
      <div className="auth-button-container">
        <Link to="/login" className="auth-button">
          Login
        </Link>
        <Link to="/register" className="auth-button">
          Register
        </Link>
      </div>
      <div className="auth-about-container">
        <Link to="/about" className="auth-about-button">
          About
        </Link>
      </div>
    </div>
  );
};

export default AuthPage;
