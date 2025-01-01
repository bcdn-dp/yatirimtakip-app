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
  const [selectedStockId, setSelectedStockId] = useState(null);

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
      // Fetch the most up-to-date stock data for the selected type
      axios.get(`https://localhost:7041/api/stocks/by-symbol?symbol=${selectedType}`)
        .then(response => {
          const sortedStocks = response.data.sort((a, b) => new Date(b.date) - new Date(a.date));
          const latestStock = sortedStocks[0];
          setUnitPrice(latestStock.close);
          setSelectedStockId(latestStock.id);
        })
        .catch(error => console.error("Error fetching stock price:", error));
    }
  }, [selectedType]);

  useEffect(() => {
    // Fetch all investments
    axios.get("https://localhost:7041/api/investments")
      .then(response => {
        setInvestments(response.data);
      })
      .catch(error => console.error("Error fetching investments:", error));
  }, []);

  const handleAddInvestment = () => {
    const investment = {
      UserID: localStorage.getItem("userId"), // Assuming userId is stored in localStorage
      StockID: selectedStockId,
      UnitAmount: unitAmount,
      UnitPrice: unitPrice,
      Type: selectedType
    };

    axios.post("https://localhost:7041/api/investments", investment)
      .then(response => {
        alert("Investment added successfully!");
        setInvestments([...investments, response.data]);
      })
      .catch(error => console.error("Error adding investment:", error));
  };

  const handleRemoveInvestment = () => {
    axios.delete(`https://localhost:7041/api/investments/${selectedInvestment}`)
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
              {investment.InvestID}
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