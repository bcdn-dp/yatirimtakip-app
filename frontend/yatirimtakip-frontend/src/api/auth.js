import axios from "axios";
import API_BASE_URL from "../config";

// Register API
export const registerUser = async (userData) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/auth/register`, userData);
        return response.data; // Success message
    } catch (error) {
        throw error.response?.data || "An error occurred during registration.";
    }
};

// Login API
export const loginUser = async (loginData) => {
    try {
        const response = await axios.post(`${API_BASE_URL}/auth/login`, loginData);
        const { Token } = response.data; // Extract the JWT token
        localStorage.setItem("jwtToken", Token); // Store the token locally
        return Token;
    } catch (error) {
        throw error.response?.data || "An error occurred during login.";
    }
};
