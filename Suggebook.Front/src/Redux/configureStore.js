import {createStore} from 'redux';
import bookReducer from './reducers/bookReducer';

export default function configureStore (initialState)
{   
    return createStore(bookReducer, initialState);
}
