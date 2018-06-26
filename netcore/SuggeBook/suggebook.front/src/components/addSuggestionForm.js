import { addSuggestion } from "../actions/suggestionActions"
import { Component } from "react"
import React from "react"
import { connect } from "react-redux"


const mapDispatchToProps = dispatch => {
    addSuggestion: suggestion => dispatch(addSuggestion(suggestion));
}

class ConnectedAddSuggestionForm extends Component {
    constructor(props) {
        super(props);

        this.state = {
            title: '',
            summary: ''
        }

        this.onTitleChange = this.onTitleChange.bind(this);
        this.onTextAreaChange = this.onTextAreaChange.bind(this);
    }

    onTitleChange(event) {
        this.setState(prevState => ({
            title: event.target.value,
            summary: prevState.summary
        }));
    }

    onTextAreaChange(event) {
        this.setState(prevState => ({
            title: prevState.title,
            summary: event.target.value
        }));
    }

    onSubmit() {
        const { title } = this.state;
        const { summary } = this.state;
        this.props.addSuggestion({
            title,
            summary
        });
        this.setState({
            title: '',
            summary: ''
        });

    }

    render() {
        return (
            <form class="addSuggestionForm">
                <input type="text" onChange={this.onTitleChange} />
                <textarea rows="4" cols="50" onChange={this.onTextAreaChange} />
            </form>
        )
    }
}

var AddSuggestionForm = connect(null, mapDispatchToProps)(ConnectedAddSuggestionForm);

export default AddSuggestionForm