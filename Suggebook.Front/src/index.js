import ReactDOM from 'react-dom';
import React from 'react'
import { Provider as ReduxProvider} from 'react-redux'
import HomeBooksContaniner from './components/book/homeBooksContainer';
import configureStore from './Redux/configureStore';


var store = configureStore({homeBooks : []});

window.React = React;

ReactDOM.render(
    <ReduxProvider store={store}>
        <HomeBooksContaniner></HomeBooksContaniner>
    </ReduxProvider>,
    document.getElementById('react-container')
);