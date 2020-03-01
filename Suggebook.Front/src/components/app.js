import React from "react";
import { Switch, Route } from "react-router-dom";
import HomeBooksContainer from "./book/homeBooksContainer";
import BookPage from "./book/bookPage";
import CustomNavbar from "./customNavbar";

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
