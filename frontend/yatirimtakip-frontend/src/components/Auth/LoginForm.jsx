import React from "react";
import "./styles/LoginForm.css";

const LoginForm = ({ onClose }) => {
  return (
    <div className="overlay">
      <div className="form-container">
        <h2>Login</h2>
        <input type="text" placeholder="Username" className="input" />
        <input type="password" placeholder="Password" className="input" />
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

export default LoginForm;
