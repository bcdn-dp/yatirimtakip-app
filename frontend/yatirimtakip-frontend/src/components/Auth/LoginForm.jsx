import React from "react";
import { useNavigate } from "react-router-dom";
import "./styles/auth-styles/LoginForm.css";

const LoginForm = () => {
  const navigate = useNavigate();

  const handleLogin = () => {
    // Simulate successful login logic
    navigate("/dashboard/home");
  };

  return (
    <div className="overlay">
      <div className="form-container">
        <h2>Login</h2>
        <input type="text" placeholder="Username" className="input" />
        <input type="password" placeholder="Password" className="input" />
        <div className="button-container">
          <button className="button" onClick={handleLogin}>
            Submit
          </button>
          <button className="button" onClick={() => navigate("/")}>
            Back
          </button>
        </div>
      </div>
    </div>
  );
};

export default LoginForm;
