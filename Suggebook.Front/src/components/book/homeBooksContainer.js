import React from "react";
import { connect } from "react-redux";
import { BookThumbnail } from "./bookThumbnail";
import { getHomeBooks } from "../../actions/bookActions";
import PropTypes from "prop-types";

class HomeBooksContainer extends React.Component {
  constructor(props) {
    super(props);
  }

  getBooks = event => {
    event.preventDefault();
    this.props.getHomeBooks();
  }

  render() {
    // const items = [];
    // for (const book of this.state.homeBooks) {
    //   items.push(<BookThumbnail title={book.title} author={book.author} />);
    // }
    return (
      <div>
        <button onClick={this.getBooks} />
      </div>
    );
  }
}

HomeBooksContainer.propTYpes = {
  homeBooks: PropTypes.array.isRequired
};

function mapDispatchToProps(dispatch) {
  return {
    getHomeBooks: () => dispatch(getHomeBooks())
  };
}

function mapStateToProps(state) {
  return {
    homeBooks: state.homeBooks
  };
}

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(HomeBooksContainer);
