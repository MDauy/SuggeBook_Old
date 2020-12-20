import ReactDOM from "react-dom";
import React from "react";
import { Provider as ReduxProvider } from "react-redux";
import configureStore from "./Redux/configureStore";
import { BrowserRouter as Router } from "react-router-dom";
import App from "./components/app";

var store = configureStore({ homeBooks: [], user: {} });

window.React = React;
ReactDOM.render(
  <div>
    <Router>
      <ReduxProvider store={store}>
        <App></App>
      </ReduxProvider>
    </Router>
  </div>,
  document.getElementById("react-container")
);
