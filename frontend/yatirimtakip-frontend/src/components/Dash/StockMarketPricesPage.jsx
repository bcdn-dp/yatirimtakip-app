import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './styles/dash-styles/StockMarketPricesPage.css';

const StockMarketPricesPage = () => {
    const [stocks, setStocks] = useState([]);
    const [symbols, setSymbols] = useState([]);
    const [selectedSymbol, setSelectedSymbol] = useState('');

    useEffect(() => {
        // Fetch all stocks
        axios.get('https://localhost:7041/api/stocks')
            .then(response => {
                setStocks(response.data);
                const uniqueSymbols = [...new Set(response.data.map(stock => stock.symbol))];
                setSymbols(uniqueSymbols);
            })
            .catch(error => console.error('Error fetching stocks:', error));
    }, []);

    useEffect(() => {
        if (selectedSymbol) {
            // Fetch stocks by selected symbol
            axios.get(`https://localhost:7041/api/stocks/by-symbol?symbol=${selectedSymbol}`)
                .then(response => setStocks(response.data))
                .catch(error => console.error('Error fetching stocks by symbol:', error));
        } else {
            // Fetch all stocks
            axios.get('https://localhost:7041/api/stocks')
                .then(response => setStocks(response.data))
                .catch(error => console.error('Error fetching stocks:', error));
        }
    }, [selectedSymbol]);

    return (
        <div className="container">
            <h1>Stock Market Prices</h1>
            <label htmlFor="symbol-select">Filter by Stock Name:</label>
            <select
                id="symbol-select"
                value={selectedSymbol}
                onChange={e => setSelectedSymbol(e.target.value)}
            >
                <option value="">All</option>
                {symbols.map(symbol => (
                    <option key={symbol} value={symbol}>{symbol}</option>
                ))}
            </select>
            <div className="table-container">
                <table>
                    <thead>
                        <tr>
                            <th>Date</th>
                            <th>Open</th>
                            <th>High</th>
                            <th>Low</th>
                            <th>Close</th>
                            <th>Adj Close</th>
                            <th>Volume</th>
                            <th>Stock Name</th>
                        </tr>
                    </thead>
                    <tbody>
                        {stocks.map(stock => (
                            <tr key={stock.id}>
                                <td>{new Date(stock.date).toLocaleDateString()}</td>
                                <td>{stock.open}</td>
                                <td>{stock.high}</td>
                                <td>{stock.low}</td>
                                <td>{stock.close}</td>
                                <td>{stock.adjClose}</td>
                                <td>{stock.volume}</td>
                                <td>{stock.symbol}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
};

export default StockMarketPricesPage;