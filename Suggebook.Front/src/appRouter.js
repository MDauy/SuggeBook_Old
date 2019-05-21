import { Route, BrowserRouter } from "react-router-dom";
import React from "react";
import LandingRedirection from "./components/landingRedirection";
function AppRouter() {
  return (
    <BrowserRouter>
        <Route exact path="/" component={LandingRedirection} />
    </BrowserRouter>
  );
}

export default AppRouter();
