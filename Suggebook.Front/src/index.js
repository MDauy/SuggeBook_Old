import ReactDOM from 'react-dom';
import React from 'react'
import { Provider as ReduxProvider} from 'react-redux'
import configureStore from '../src/Redux/configureStore';
import HomeBooksContainer from './components/book/homeBooksContainer'


var store = configureStore({homeBooks : [], user :{}});

window.React = React;

ReactDOM.render(
    <ReduxProvider store={store}>
        <HomeBooksContainer></HomeBooksContainer>
    </ReduxProvider>,
    document.getElementById('react-container')
);