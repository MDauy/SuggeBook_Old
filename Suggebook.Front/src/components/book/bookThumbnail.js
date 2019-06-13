import React from "react";

export class BookThumbnail extends React.Component {
  constructor(props) {
    super(props);
    const book = this.props.book;
    this.state = {
      title: book.title,
      author: book.author,
      id: book.id
    };
  }

  render() {
    return (
      <div>
        {this.state.title} {this.state.author.fullname}
      </div>
    );
  }
}
