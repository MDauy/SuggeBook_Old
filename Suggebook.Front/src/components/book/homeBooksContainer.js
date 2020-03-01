import React from "react";
import axios from "axios";
import { URLS } from "../../consts";
import { Link} from "react-router-dom";

export default class HomeBooksContainer extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      homeBooks: []
    };
  }

  componentDidMount() {
    axios.get(URLS.GET_HOME_BOOKS).then(res => {
      this.setState({
        homeBooks: res.data
      });
    });
  }

  render() {
    return (
      <div>
        <ul>
          {this.state.homeBooks &&
            this.state.homeBooks.map((book, index) => (
              <Link key={index} to={`/book/${book.id}`}>
                <p>{book.title}</p>
              </Link>
            ))}
        </ul>
      </div>
    );
  }
}
