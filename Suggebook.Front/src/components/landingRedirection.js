import React from "react";
import HomeBooksContainer from "./book/homeBooksContainer";
import { connect } from "react-redux";
class LandingRedirection extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
    };
  }

  render() {
    return <HomeBooksContainer />;
  }
}

function mapStateToProps(state) {
  return {
    user: state.user
  };
}

export default connect(mapStateToProps, null)(LandingRedirection);
