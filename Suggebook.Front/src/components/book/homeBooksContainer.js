import React from "react";
import axios from 'axios';
import {URLS} from '../../consts'
import BookThumbnail from './bookThumbnail'

export default class HomeBooksContainer extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      homeBooks: []
    };
  }

  componentDidMount()
  {
    axios.get(URLS.GET_HOME_BOOKS)
    .then(res => 
      {
        this.setState ( 
          {
            homeBooks : res.data
          })
      })
  }

  render() {
    return (
      <div>
        <ul>
          {this.state.homeBooks && this.state.homeBooks.map((book, index) => (
            <BookThumbnail key={index} book={book}></BookThumbnail>
          ))}
        </ul>
      </div>
    );
  }
}