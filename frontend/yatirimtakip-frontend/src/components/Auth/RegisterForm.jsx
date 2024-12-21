import React, { useState } from "react";
import { Link } from "react-router-dom";
import { registerUser } from "../../api/auth";
import "./styles/auth-styles/RegisterForm.css";

const RegisterForm = () => {
  const [formData, setFormData] = useState({ username: "", email: "", password: "" });
  const [message, setMessage] = useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();
    setMessage("");

    // Client-side validation
    if (formData.username.length < 3 || formData.username.length > 15) {
      setMessage("Username must be between 3 and 15 characters.");
      return;
    }
    if (!/\S+@\S+\.\S+/.test(formData.email)) {
      setMessage("Invalid email format.");
      return;
    }
    if (formData.password.length < 6) {
      setMessage("Password must be at least 6 characters long.");
      return;
    }

    try {
      console.log("Sending data to API:", formData);
      const result = await registerUser(formData);
      console.log("API Response:", result);
      setMessage(result);
  } catch (err) {
      console.error("Error during registration:", err);
      setMessage(err);
  }
  };

  return (
    <div className="overlay">
      <div className="form-container">
        <h2>Register</h2>
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
          <input
            type="email"
            placeholder="Email"
            className="input"
            value={formData.email}
            onChange={(e) => setFormData({ ...formData, email: e.target.value })}
            required
          />
          <div className="button-container">
            <button className="button" type="submit">
              Submit
            </button>
            <Link to="/" className="button">
              Back
            </Link>
          </div>
        </form>
        <p>{message}</p>
      </div>
    </div>
  );
};

export default RegisterForm;
