import React, { useState, useEffect } from "react";
import axios from "axios";
import "./styles/dash-styles/ManageInvestmentsPage.css";

const ManageInvestmentsPage = () => {
  const [stocks, setStocks] = useState([]);
  const [selectedType, setSelectedType] = useState("");
  const [unitAmount, setUnitAmount] = useState(0);
  const [unitPrice, setUnitPrice] = useState(0);
  const [stockTypes, setStockTypes] = useState([]);
  const [investments, setInvestments] = useState([]);
  const [selectedInvestment, setSelectedInvestment] = useState("");
  const [message, setMessage] = useState("");

  useEffect(() => {
    // Fetch all stocks
    axios.get("https://localhost:7041/api/stocks")
      .then(response => {
        setStocks(response.data);
        const uniqueTypes = [...new Set(response.data.map(stock => stock.symbol))];
        setStockTypes(uniqueTypes);
      })
      .catch(error => console.error("Error fetching stocks:", error));
  }, []);

  useEffect(() => {
    if (selectedType) {
      // Fetch the most up-to-date close price for the selected stock type
      axios.get(`https://localhost:7041/api/stocks/by-symbol?symbol=${selectedType}`)
        .then(response => {
          const latestStock = response.data[0]; // Assuming the latest stock is the first in the array
          setUnitPrice(latestStock.close);
        })
        .catch(error => console.error("Error fetching stock price:", error));
    }
  }, [selectedType]);

  useEffect(() => {
    // Fetch investments for the logged-in user
    const userId = localStorage.getItem("userId"); // Assuming userId is stored in localStorage
    axios.get(`https://localhost:7041/api/investments/user/${userId}`)
      .then(response => {
        setInvestments(response.data);
      })
      .catch(error => console.error("Error fetching investments:", error));
  }, []);

  const handleAddInvestment = () => {
    const investment = {
      UnitAmount: unitAmount,
      Type: selectedType,
      UnitPrice: unitPrice
    };

    axios.post("https://localhost:7041/api/investments", investment)
      .then(response => {
        alert("Investment added successfully!");
      })
      .catch(error => console.error("Error adding investment:", error));
  };

  const handleRemoveInvestment = () => {
    const userId = localStorage.getItem("userId"); // Assuming userId is stored in localStorage
    axios.delete(`https://localhost:7041/api/investments/${userId}/${selectedInvestment}`)
      .then(response => {
        setMessage("Investment deleted successfully!");
        // Remove the deleted investment from the state
        setInvestments(investments.filter(inv => inv.InvestID !== selectedInvestment));
      })
      .catch(error => console.error("Error deleting investment:", error));
  };

  return (
    <div className="container">
      <div className="welcome-box">
        <h1 className="welcome-text">Manage Investments</h1>
      </div>
      <div className="add-investment">
        <h2>Add Investment</h2>
        <label htmlFor="type-select">Stock Type:</label>
        <select
          id="type-select"
          value={selectedType}
          onChange={e => setSelectedType(e.target.value)}
        >
          <option value="">Select Type</option>
          {stockTypes.map(type => (
            <option key={type} value={type}>{type}</option>
          ))}
        </select>
        <label htmlFor="unit-amount">Unit Amount:</label>
        <input
          type="number"
          id="unit-amount"
          value={unitAmount}
          onChange={e => setUnitAmount(e.target.value)}
        />
        <label htmlFor="unit-price">Unit Price:</label>
        <input
          type="text"
          id="unit-price"
          value={unitPrice}
          readOnly
        />
        <button onClick={handleAddInvestment}>Add Investment</button>
      </div>
      <div className="remove-investment">
        <h2>Remove Investment</h2>
        <label htmlFor="investment-select">Select Investment:</label>
        <select
          id="investment-select"
          value={selectedInvestment}
          onChange={e => setSelectedInvestment(e.target.value)}
        >
          <option value="">Select Investment</option>
          {investments.map(investment => (
            <option key={investment.InvestID} value={investment.InvestID}>
              {investment.InvestID} - {investment.Type}
            </option>
          ))}
        </select>
        <button onClick={handleRemoveInvestment}>Remove Investment</button>
        {message && <p>{message}</p>}
      </div>
    </div>
  );
};

export default ManageInvestmentsPage;