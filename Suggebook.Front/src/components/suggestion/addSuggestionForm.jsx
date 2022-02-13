import { addSuggestion } from "../../actions/suggestionActions"
import { Component } from "react"
import React from "react"
import { connect } from "react-redux"
import styles from "../styles/suggestionForm.css"
import Popup from "reactjs-popup"

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
            <Popup trigger={<button>Ajouter une suggestion</button>} modal position="center" closeOnDocumentClick>
            {close => (
                <div class="form-container">
                    <div className="header" id="addSuggestionHeader">Un livre à suggérer ?</div>
                    <div id={styles.suggestionFormPopin} className="content">
                        <form id="addSuggestionForm">
                            <div class="form-group">
                                <label for="suggestionTitleInput">Qu'en avez-vous pensé ?</label>
                                <input class="form-control" id="suggestionTitleInput" type="text" onChange={this.onTitleChange} />
                            </div>
                            <div class="form-group">
                                <label for="suggestionSummaryInput">Un dernier mot ?</label>
                                <textarea class="form-control" id="suggestionSummaryInput" rows="4" cols="50" onChange={this.onTextAreaChange} />
                            </div>
                            <button type="submit" id="addButton" class="btn btn-default" onClick={() => {this.onSubmit(); close();}}>Ajouter</button>
                        </form>
                    </div>
                </div>
                )}
            </Popup>
        )
    }
}


var AddSuggestionForm = connect(null, mapDispatchToProps)(ConnectedSuggestionForm);

export default AddSuggestionForm