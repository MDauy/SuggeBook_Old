import React from "react";
import { Switch, Route } from "react-router-dom";
import HomeBooksContainer from "./book/homeBooksContainer.jsx";
import BookPage from "./book/bookPage.jsx";
import CustomNavbar from "./customNavbar.jsx";

function App() {
  return (
    <div>
      <CustomNavbar></CustomNavbar>
      <Switch>
        <Route exact path="/" component={HomeBooksContainer}></Route>
        <Route path="/book/:bookId" component={BookPage}></Route>
      </Switch>
    </div>
  );
}

export default App;
