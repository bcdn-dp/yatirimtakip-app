import React from "react";
import { Link } from "react-router-dom";
import "./styles/AboutPopup.css";

const AboutPopup = () => {
  return (
    <div className="overlay">
      <div className="popup">
        <p className="text">Made by X</p>
        <Link to="/" className="close-button">
          Back
        </Link>
      </div>
    </div>
  );
};

export default AboutPopup;
