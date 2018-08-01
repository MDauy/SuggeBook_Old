import ReactDOM from 'react-dom';
import React from 'react'
import AddSuggestionForm from './components/suggestionForm'
import { Provider } from 'react-redux'
import { createStore } from 'redux'
import suggestionReducer from './reducers/suggestionReducer'
import {Popup} from "react-popup"

var store = createStore(suggestionReducer);

window.React = React;

displayForm = function(eventArgs) {
    Popup.plugins().addSuggestionForm()
};

ReactDOM.render(
    <Provider store={store}>
       <button type="text" class="btn btn-default" onClick="{this.displayForm}">Formulaire d'ajout</button>
    </Provider>,
    document.getElementById('react-container')
);

Popup.registerPlugin('addSuggestionForm', function(callback){
    this.create ({
        title:'Ajoutez une suggestion',
        content:<SuggestionForm></SuggestionForm>,
        buttons:{
            left:['Annuler'],
            right:[{
                text : 'Ajouter',
                className: 'btn btn-default',
                action : function (){
                    callback();
                    Popup.close();
                }
            }]
        }
    });
});