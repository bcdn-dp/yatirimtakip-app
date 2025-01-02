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
        setMessage(""); // Clear previous messages

        try {
            const response = await loginUser(formData); // Call the login API
            localStorage.setItem("jwtToken", response.token); // Store the JWT token
            localStorage.setItem("userId", response.userId); // Store the User ID
            setMessage("Login successful!"); // Display success message
            navigate("/dashboard/home"); // Redirect to dashboard
        } catch (err) {
            // Log the error for debugging
            console.error("Error during login:", err.response ? err.response.data : err.message);

            // Check if the error response contains a meaningful message
            if (err.response && err.response.data) {
                const errorMessage = err.response.data.message || "Login failed. Please try again.";
                setMessage(errorMessage); // Set a user-friendly error message
            } else {
                setMessage("An unexpected error occurred. Please try again.");
            }
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