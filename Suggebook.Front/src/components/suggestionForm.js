import { addSuggestion } from "../actions/suggestionActions"
import { Component } from "react"
import React from "react"
import { connect } from "react-redux"
import styles from "../styles/suggestionForm.css"
import {PureComponent} from "react-redux-popup"

const mapDispatchToProps = dispatch => {
    addSuggestion: suggestion => dispatch(addSuggestion(suggestion));
}



class ConnectedSuggestionForm extends Component {
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
            <div id={styles.suggestionFormPopin}>
            <form id="addSuggestionForm">
                <div class="form-group">
                    <label for="suggestionTitleInput">Qu'en avez-vous pensé ?</label>
                    <input class="form-control" id="suggestionTitleInput" type="text" onChange={this.onTitleChange} />
                </div>
                <div class="form-group">
                <label for="suggestionSummaryInput">Un dernier mot ?</label>
                    <textarea class="form-control" id="suggestionSummaryInput" rows="4" cols="50" onChange={this.onTextAreaChange} />
                </div>
            </form>
            </div>
        )
    }
}


var SuggestionForm = connect(null, mapDispatchToProps)(ConnectedSuggestionForm);

export default SuggestionForm