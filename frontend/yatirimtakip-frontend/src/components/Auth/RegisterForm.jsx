import React from "react";
import { Link } from "react-router-dom";
import "./styles/RegisterForm.css";

const RegisterForm = () => {
  return (
    <div className="overlay">
      <div className="form-container">
        <h2>Register</h2>
        <input type="text" placeholder="Username" className="input" />
        <input type="password" placeholder="Password" className="input" />
        <input type="email" placeholder="Email" className="input" />
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

export default RegisterForm;
