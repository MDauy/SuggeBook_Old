import React from "react";
import { connectUser } from "../../redux/actions/userActions";
import { connect } from "react-redux";
import "../../styles/loginForm.scss";
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

  render() {
    return (
      <div id="login-form-container">
        <form className="form-container" id="login-form">
          <div className="form-group">
            <label htmlFor="mail-input">Mail ou nom d'utilisateur</label>
            <input className="form-control" id="mail-input" type="text" />
          </div>
          <div className="form-group">
            <label htmlFor="password-input">Mot de passe</label>
            <input className="form-control" id="password-input" type="password" />
          </div>
        </form>
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
