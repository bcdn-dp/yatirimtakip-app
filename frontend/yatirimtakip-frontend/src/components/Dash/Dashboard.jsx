import React from "react";
import { Link, Route, Routes } from "react-router-dom";
import HomePage from "./HomePage";
import StockMarketPricesPage from "./StockMarketPricesPage";
import ManageInvestmentsPage from "./ManageInvestmentsPage";
import ViewInvestmentsPage from "./ViewInvestmentsPage";
import "./styles/dash-styles/Dashboard.css";
import "./styles/dash-styles/Sidebar.css";

const Dashboard = () => {
  return (
    <div className="dashboard-container">
      <nav className="sidebar">
        {/* App Logo */}
        <div className="logo">
          <img src="/icons/icon_pie-chart.png" alt="App Logo" className="logo-icon" />
        </div>
        {/* Sidebar Links with Icons */}
        <Link to="/dashboard/home" className="sidebar-link">
          <img src="/icons/icon_home.png" alt="Home" className="sidebar-icon" />
        </Link>
        <Link to="/dashboard/stocks" className="sidebar-link">
          <img src="/icons/icon_line-chart.png" alt="Stock Market Prices" className="sidebar-icon" />
        </Link>
        <Link to="/dashboard/manage" className="sidebar-link">
          <img src="/icons/icon_money.png" alt="Manage Investments" className="sidebar-icon" />
        </Link>
        <Link to="/dashboard/view-investments" className="sidebar-link">
          <img src="/icons/icon_desktop.png" alt="View Investments" className="sidebar-icon" />
        </Link>
      </nav>
      <main className="dashboard-main">
        <Routes>
          <Route path="home" element={<HomePage />} />
          <Route path="stocks" element={<StockMarketPricesPage />} />
          <Route path="manage" element={<ManageInvestmentsPage />} />
          <Route path="view-investments" element={<ViewInvestmentsPage />} />
        </Routes>
      </main>
    </div>
  );
};

export default Dashboard;
