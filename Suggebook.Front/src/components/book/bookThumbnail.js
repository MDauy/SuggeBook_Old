import React from "react";

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
        {this.state.title} {this.state.authors.map((a, index) =>
          {
            return (<span key={index}>{a}</span>)
          })}
      </div>
    );
  }
}
