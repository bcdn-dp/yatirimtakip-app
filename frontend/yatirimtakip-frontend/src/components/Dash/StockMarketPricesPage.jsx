import React, { useEffect, useState } from "react";
import axios from "axios";
import "./styles/dash-styles/StockMarketPricesPage.css";

const StockMarketPricesPage = () => {
  const [stockData, setStockData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  const fetchStockData = async () => {
    try {
      const response = await axios.get("http://localhost:5235/api/stockmarket/all");
      setStockData(response.data);
      setLoading(false);
    } catch (err) {
      setError(err.message);
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchStockData();
    const interval = setInterval(fetchStockData, 600000); // 10 minutes in milliseconds
    return () => clearInterval(interval);
  }, []);

  if (loading) return <div>Loading...</div>;
  if (error) return <div>Error: {error}</div>;

  return (
    <div className="container">
      <div className="welcome-box">
        <h1 className="welcome-text">Stock Market Prices</h1>
      </div>
      <table className="stock-table">
        <thead>
          <tr>
            <th>Date</th>
            <th>Symbol</th>
            <th>Open</th>
            <th>High</th>
            <th>Low</th>
            <th>Close</th>
            <th>Volume</th>
          </tr>
        </thead>
        <tbody>
          {stockData.map((stock, index) => (
            <tr key={index}>
              <td>{new Date(stock.date).toLocaleDateString()}</td>
              <td>{stock.symbol}</td>
              <td>{stock.open}</td>
              <td>{stock.high}</td>
              <td>{stock.low}</td>
              <td>{stock.close}</td>
              <td>{stock.volume}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default StockMarketPricesPage;