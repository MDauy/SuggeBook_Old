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
       <button type="text" class="btn btn-default" onClick="{this.displayForm}">Formulaire d'ajout</button>
       <Popup getRect={() => elem.getBoundingClientRect()}
            id="popup1"
            render={() => <AddSuggestionForm />}></Popup>
    </Provider>,
    document.getElementById('react-container')
);