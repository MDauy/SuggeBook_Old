import React from "react"

export class BookThumbnail extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            title: '',
            author: '',
            id: ''
        }
    }

    render() {
        return (
            <div>
                {this.title}  {this.author}
            </div>)
    }
}