import React, { useState } from "react";
import axios from "axios";
import "./styles/auth-styles/AdminPanel.css";

const AdminPanel = () => {
  const [message, setMessage] = useState("");
  const [data, setData] = useState(null);
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const handleLogin = (e) => {
    e.preventDefault();
    if (username === "admin" && password === "admin") {
      setIsAuthenticated(true);
      setMessage("Login successful!");
    } else {
      setMessage("Invalid username or password.");
    }
  };

  const handleGetStocks = async () => {
    try {
      const response = await axios.get("https://localhost:7041/api/stocks");
      setData({ type: "stocks", content: response.data });
      setMessage("Stocks fetched successfully!");
    } catch (error) {
      setMessage("Error fetching stocks.");
    }
  };

  const handleGetUsers = async () => {
    try {
      const response = await axios.get("https://localhost:7041/api/users");
      setData({ type: "users", content: response.data });
      setMessage("Users fetched successfully!");
    } catch (error) {
      setMessage("Error fetching users.");
    }
  };

  const handleGetInvestments = async () => {
    try {
      const response = await axios.get("https://localhost:7041/api/investments");
      setData({ type: "investments", content: response.data });
      setMessage("Investments fetched successfully!");
    } catch (error) {
      setMessage("Error fetching investments.");
    }
  };

  const handleImportCsv = async () => {
    try {
      await axios.post("https://localhost:7041/api/stocks/import-csv");
      setMessage("CSV files imported successfully!");
    } catch (error) {
      setMessage("Error importing CSV files.");
    }
  };

  const handleDeleteAllStocks = async () => {
    try {
      await axios.delete("https://localhost:7041/api/stocks/delete-all");
      setMessage("All stocks deleted successfully!");
    } catch (error) {
      setMessage("Error deleting stocks.");
    }
  };

  const renderTable = () => {
    if (!data) return null;

    const { type, content } = data;

    if (type === "stocks") {
      return (
        <table>
          <thead>
            <tr>
              <th>ID</th>
              <th>Date</th>
              <th>Open</th>
              <th>High</th>
              <th>Low</th>
              <th>Close</th>
              <th>Volume</th>
              <th>Symbol</th>
            </tr>
          </thead>
          <tbody>
            {content.map((stock) => (
              <tr key={stock.id}>
                <td>{stock.id}</td>
                <td>{new Date(stock.date).toLocaleDateString()}</td>
                <td>{stock.open}</td>
                <td>{stock.high}</td>
                <td>{stock.low}</td>
                <td>{stock.close}</td>
                <td>{stock.volume}</td>
                <td>{stock.symbol}</td>
              </tr>
            ))}
          </tbody>
        </table>
      );
    }

    if (type === "users") {
      return (
        <table>
          <thead>
            <tr>
              <th>UserID</th>
              <th>Username</th>
              <th>Email</th>
            </tr>
          </thead>
          <tbody>
            {content.map((user) => (
              <tr key={user.userID}>
                <td>{user.userID}</td>
                <td>{user.username}</td>
                <td>{user.email}</td>
              </tr>
            ))}
          </tbody>
        </table>
      );
    }

    if (type === "investments") {
      return (
        <table>
          <thead>
            <tr>
              <th>InvestID</th>
              <th>UserID</th>
              <th>StockID</th>
              <th>UnitPrice</th>
              <th>UnitAmount</th>
            </tr>
          </thead>
          <tbody>
            {content.map((investment) => (
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
      );
    }

    return null;
  };

  return (
    <div className="overlay">
      <div className="admin-panel-container">
        <div className="form-container">
          {!isAuthenticated ? (
            <form onSubmit={handleLogin}>
              <h2>Admin Login</h2>
              <input
                type="text"
                placeholder="Username"
                className="input"
                value={username}
                onChange={(e) => setUsername(e.target.value)}
                required
              />
              <input
                type="password"
                placeholder="Password"
                className="input"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                required
              />
              <div className="button-container">
                <button className="button" type="submit">
                  Login
                </button>
              </div>
            </form>
          ) : (
            <>
              <h2>Admin Panel</h2>
              <div className="button-container">
                <button className="button" onClick={handleGetStocks}>
                  Display Stocks
                </button>
                <button className="button" onClick={handleGetUsers}>
                  Display Users
                </button>
                <button className="button" onClick={handleGetInvestments}>
                  Display Investments
                </button>
                <button className="button" onClick={handleImportCsv}>
                  Import All CSV Stock Files
                </button>
                <button className="button" onClick={handleDeleteAllStocks}>
                  Delete All Stocks
                </button>
              </div>
              {message && <p>{message}</p>}
            </>
          )}
        </div>
        {isAuthenticated && (
          <div className="data-display">{renderTable()}</div>
        )}
      </div>
    </div>
  );
};

export default AdminPanel;