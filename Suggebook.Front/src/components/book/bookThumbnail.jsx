import React from "react";
import { Link } from "react-router-dom";
import '../../styles/bookThumbnail.less';

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
      <div class="book-thumbnail">
        <img class="book-thumbnail__img" alt="" src="https://m.media-amazon.com/images/I/413o7a8ikHL.jpg"></img>
        <Link to={`/book/${this.state.id}`}>{this.state.title}</Link>
        <div>
        {this.state.authors.map((author, index) => (
          <Link class="book-thumbnail__author" to={`/author/${author}`} key={index}>{author.name}</Link>
        ))}
        </div>
      </div>
    );
  }
}
