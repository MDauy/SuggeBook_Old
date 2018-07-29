import ReactDOM from 'react-dom';
import React from 'react'
import AddSuggestionForm from './components/suggestionForm'
import { Provider } from 'react-redux'
import { createStore } from 'redux'
import suggestionReducer from './reducers/suggestionReducer'

var store = createStore(suggestionReducer);

window.React = React;

ReactDOM.render(
    <Provider store={store}>
        <AddSuggestionForm />
    </Provider>,
    document.getElementById('react-container')
);