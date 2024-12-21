import axios from "axios";
import API_BASE_URL from "../config";

// Register API
export const registerUser = async (userData) => {
  try {
      const response = await axios.post(`${API_BASE_URL}/auth/register`, userData);
      return response.data;
  } catch (error) {
      console.error("Register API Error:", error.response?.data || error.message);
      throw error.response?.data || "Registration failed. Please try again.";
  }
};


// Login API
export const loginUser = async (loginData) => {
  try {
      console.log("Sending login request:", loginData);
      const response = await axios.post(`${API_BASE_URL}/auth/login`, loginData);
      console.log("Login API Response:", response.data);
      return response.data.Token;
  } catch (error) {
      console.error("Login API Error:", error.response?.data || error.message);
      throw error.response?.data || "An unexpected error occurred. Please try again.";
  }
};



