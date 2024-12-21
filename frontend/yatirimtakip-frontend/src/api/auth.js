import axios from "axios";
import API_BASE_URL from "../config";

// Register API
export const registerUser = async (userData) => {
  try {
    const response = await axios.post(`${API_BASE_URL}/auth/register`, userData);
    return response.data;
  } catch (error) {
    throw error.response?.data || "Registration failed. Please try again.";
  }
};

// Login API
export const loginUser = async (loginData) => {
  try {
    const response = await axios.post(`${API_BASE_URL}/auth/login`, loginData);
    return response.data.Token; // Extract the JWT token
  } catch (error) {
    throw error.response?.data || "Login failed. Please try again.";
  }
};
