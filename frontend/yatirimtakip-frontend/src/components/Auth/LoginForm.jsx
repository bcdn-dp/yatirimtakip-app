import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { loginUser } from "../../api/auth";
import "./styles/auth-styles/LoginForm.css";

const LoginForm = () => {
  const [formData, setFormData] = useState({ username: "", password: "" });
  const [message, setMessage] = useState("");
  const navigate = useNavigate();

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (!formData.username || !formData.password) {
      setMessage("Username and password are required.");
      return;
    }

    try {
      // Call the login API
      const token = await loginUser(formData);
      localStorage.setItem("jwtToken", token); // Store JWT token
      setMessage("Login successful!");
      navigate("/dashboard/home"); // Redirect to Dashboard
    } catch (err) {
      setMessage(err); // Error message
    }
  };

  return (
    <div className="overlay">
      <div className="form-container">
        <h2>Login</h2>
        <form onSubmit={handleSubmit}>
          <input
            type="text"
            placeholder="Username"
            className="input"
            value={formData.username}
            onChange={(e) => setFormData({ ...formData, username: e.target.value })}
            required
          />
          <input
            type="password"
            placeholder="Password"
            className="input"
            value={formData.password}
            onChange={(e) => setFormData({ ...formData, password: e.target.value })}
            required
          />
          <div className="button-container">
            <button className="button" type="submit">
              Submit
            </button>
            <button className="button" onClick={() => navigate("/")}>
              Back
            </button>
          </div>
        </form>
        <p>{message}</p>
      </div>
    </div>
  );
};

export default LoginForm;
