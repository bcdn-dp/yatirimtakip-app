import React from "react";
import "./styles/RegisterForm.css";

const RegisterForm = ({ onClose }) => {
  return (
    <div className="overlay">
      <div className="form-container">
        <h2>Register</h2>
        <input type="text" placeholder="Username" className="input" />
        <input type="password" placeholder="Password" className="input" />
        <input type="email" placeholder="Email" className="input" />
        <div className="button-container">
          <button className="button">Submit</button>
          <button className="button" onClick={onClose}>
            Close
          </button>
        </div>
      </div>
    </div>
  );
};

export default RegisterForm;
