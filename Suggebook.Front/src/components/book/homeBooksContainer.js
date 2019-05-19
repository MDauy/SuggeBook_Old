import React from "react";
import { connect } from "react-redux";
import { getHomeBooks } from "../../redux/actions/bookActions";
import PropTypes from "prop-types";
import { BookThumbnail } from './bookThumbnail';

class HomeBooksContainer extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      homeBooks : []
    }
  }

  render() {
    this.props.getHomeBooks();
    return (
      <div>
        <ul>
          {this.props.homeBooks.map ((book) => 
            
            <BookThumbnail key={book.id} book={book}></BookThumbnail>
            
            )}
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
    getHomeBooks: () => getHomeBooks(dispatch)
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
