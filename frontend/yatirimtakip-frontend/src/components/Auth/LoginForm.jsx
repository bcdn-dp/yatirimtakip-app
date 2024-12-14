import React from "react";
import { Link } from "react-router-dom";
import "./styles/LoginForm.css";

const LoginForm = () => {
  return (
    <div className="overlay">
      <div className="form-container">
        <h2>Login</h2>
        <input type="text" placeholder="Username" className="input" />
        <input type="password" placeholder="Password" className="input" />
        <div className="button-container">
          <button className="button">Submit</button>
          <Link to="/" className="button">
            Back
          </Link>
        </div>
      </div>
    </div>
  );
};

export default LoginForm;
