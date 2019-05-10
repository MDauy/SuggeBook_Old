import {createStore} from 'redux';
import bookReducer from './bookReducer';

export default function configureStore (initialState)
{   
    return createStore(bookReducer, initialState);
}
