import React from "react";
import { connect } from "react-redux";
import { getHomeBooks } from "../../Redux/actions/bookActions";
import PropTypes from "prop-types";
import { BookThumbnail } from './bookThumbnail';

class HomeBooksContainer extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      homeBooks : []
    }
  }
  getBooks = event => {
    event.preventDefault();
    this.props.getHomeBooks();
  };

  render() {
    return (
      <div>
        <button onClick={this.getBooks}>Tester</button>
        <ul>
          {this.props.homeBooks.map ((book) => 
            {
            <BookThumbnail book={book}></BookThumbnail>
            })}
        </ul>
      </div>
    );
  }
}

HomeBooksContainer.propTYpes = {
  homeBooks: PropTypes.array.isRequired
};

//les properties & actions mises dans mapDispatchToProps et mapStateToProps peuvent ensuite 
//être accédés via this.props

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
