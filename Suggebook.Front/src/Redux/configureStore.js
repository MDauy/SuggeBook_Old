import {createStore, combineReducers} from 'redux';
import bookReducer from './reducers/bookReducer';
import userReducer from './reducers/userReducer';

export default function configureStore (initialState)
{
    const combinedReducers = combineReducers (bookReducer, userReducer)
    return createStore(combinedReducers, initialState);
}
