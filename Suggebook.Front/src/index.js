import ReactDOM from "react-dom";
import React from "react";
import { Provider as ReduxProvider } from "react-redux";
import configureStore from "../src/Redux/configureStore";
import { BrowserRouter as Router } from "react-router-dom";
import App from "./components/app";
import "bootstrap/dist/css/bootstrap.min.css";

var store = configureStore({ homeBooks: [], user: {} });

window.React = React;
ReactDOM.render(
  <div>
    <link
      rel="stylesheet"
      href="https://maxcdn.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
      integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T"
      crossOrigin="anonymous"
    />
    <Router>
      <ReduxProvider store={store}>
        <App></App>
      </ReduxProvider>
    </Router>
  </div>,
  document.getElementById("react-container")
);
