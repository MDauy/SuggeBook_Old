import React from "react";
import {Link} from "react-router-dom";

export default class BookThumbnail extends React.Component {
  constructor(props) {
    super(props);
    const book = this.props.book;
    this.state = {
      title: book.title,
      authors: book.authors,
      id: book.id
    };
  }

  render() {
    return (
      <div>
        <Link to={`/book/${this.state.id}`}>{this.state.title}</Link>
      </div>
    );
  }
}
