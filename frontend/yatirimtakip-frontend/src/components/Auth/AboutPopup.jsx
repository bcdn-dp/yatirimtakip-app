import React from "react";
import "./styles/AboutPopup.css";

const AboutPopup = ({ onClose }) => {
  return (
    <div className="overlay">
      <div className="popup">
        <p className="text">Made by [name]</p>
        <button className="close-button" onClick={onClose}>
          Close
        </button>
      </div>
    </div>
  );
};

export default AboutPopup;
