import ReactDOM from 'react-dom';
import React from 'react'
import { Provider as ReduxProvider} from 'react-redux'
import configureStore from './redux/reducers/configureStore';
import LandingRedirection from './components/landingRedirection'
import './styles/index.scss' 



var store = configureStore();

window.React = React;

ReactDOM.render(
    <ReduxProvider store={store}>
        <LandingRedirection></LandingRedirection>
    </ReduxProvider>,
    document.getElementById('react-container')
);