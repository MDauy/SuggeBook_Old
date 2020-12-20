import React from "react";
import {URLS} from '../../consts'
import axios from 'axios'

export default class BookPage extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      id : props.match.params.bookId
    };
  }

  componentDidMount()
  {
    var getBookUrl = URLS.GET_BOOK + this.state.id;
    axios.get (getBookUrl)
    .then (response => {
      let book = response.data;
      this.setState(
        {
          title : book.title,
          authors : book.authors,
          nb_suggestions : book.nb_suggestions,
          categories : book.categories,
          published_date : book.published_date,
          saga_id : book.saga_id,
          saga_position : book.saga_position,
          synopsis : book.synopsis
        }
      )
    })
  }

  render() {
    return (
      <div>
        BOOK PAGE
        <p>{this.state.title}</p>
        <div>
        {this.state.authors && this.state.authors.map((author, index) => 
        (
          <p key={index}>{author}</p>
        ))}
        </div>
      </div>
    );
  }
}
