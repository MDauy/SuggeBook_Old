import ReactDOM from 'react-dom';
import React from 'react'
import { Provider as ReduxProvider} from 'react-redux'
import configureStore from './redux/configureStore';
import LandingRedirection from './components/landingRedirection'


var store = configureStore({homeBooks : [], user :{}});

window.React = React;

ReactDOM.render(
    <ReduxProvider store={store}>
        <LandingRedirection></LandingRedirection>
    </ReduxProvider>,
    document.getElementById('react-container')
);