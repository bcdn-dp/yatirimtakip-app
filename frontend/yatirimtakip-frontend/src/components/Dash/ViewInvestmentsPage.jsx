import React, { useState, useEffect } from "react";
import axios from "axios";
import "./styles/dash-styles/ViewInvestmentsPage.css";

const ViewInvestmentsPage = () => {
  const [investments, setInvestments] = useState([]);

  useEffect(() => {
    // Fetch all investments
    axios.get("https://localhost:7041/api/investments")
      .then(response => {
        setInvestments(response.data);
      })
      .catch(error => console.error("Error fetching investments:", error));
  }, []);

  return (
    <div className="container">
      <div className="welcome-box">
        <h1 className="welcome-text">View Investments</h1>
      </div>
      <div className="table-container">
        <table>
          <thead>
            <tr>
              <th>Investment ID</th>
              <th>User ID</th>
              <th>Stock ID</th>
              <th>Unit Price</th>
              <th>Unit Amount</th>
            </tr>
          </thead>
          <tbody>
            {investments.map(investment => (
              <tr key={investment.investID}>
                <td>{investment.investID}</td>
                <td>{investment.userID}</td>
                <td>{investment.stockID}</td>
                <td>{investment.unitPrice}</td>
                <td>{investment.unitAmount}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default ViewInvestmentsPage;