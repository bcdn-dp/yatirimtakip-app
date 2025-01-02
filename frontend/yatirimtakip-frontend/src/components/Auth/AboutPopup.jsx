import React from "react";
import { Link } from "react-router-dom";
import "./styles/auth-styles/AboutPopup.css";


const AboutPopup = () => {
  return (
    <div className="overlay">
      <div className="popup">
        <p className="text">Made by 22196375</p>
        <Link to="/" className="close-button">
          Back
        </Link>
      </div>
    </div>
  );
};

export default AboutPopup;
