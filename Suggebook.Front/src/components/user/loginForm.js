import React from "react";
import { connectUser } from "../../redux/actions/userActions";
import { connect } from "react-redux";
import "../../styles/loginForm.scss";
import {BrowserRouter as Router, Link, Route, Redirect } from "react-router-dom";
import SignUp from "./sign-up";
class LoginForm extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      username: "",
      mail: "",
      password: "",
      favorite_categories: []
    };
  }

  onUsernameChange(event) {}

  onSecondPasswordCompleted(event) {}

  onSubmit(event) {}

  redirectToSignup = () => {
    this.props.history.push("/sign-up");
  };

  render() {
    return (
      <div id="login-form-container">
        <h1>Se connecter</h1>
        <div className="form-container">
          <form id="login-form">
            <div className="form-group">
              <label htmlFor="mail-input">Mail ou nom d'utilisateur</label>
              <input className="form-control" id="mail-input" type="text" />
            </div>
            <div className="form-group">
              <label htmlFor="password-input">Mot de passe</label>
              <input
                className="form-control"
                id="password-input"
                type="password"
              />
            </div>
          </form>
          <Router>
            <br />
            <Link to={"/sign-up"}>
              1ère visite ?
            </Link>
            <Route exact path="/sign-up" component={SignUp} />
          </Router>
        </div>
      </div>
    );
  }
}

function mapDispatchToProps(dispatch) {
  return {
    connectUser: user => connectUser(user, dispatch)
  };
}

export default connect(
  null,
  mapDispatchToProps
)(LoginForm);
