import { createStore, combineReducers } from "redux";
import bookReducer from "./bookReducer";
import userReducer from "./userReducer";

export default function configureStore() {
  const initialState = {
    book: { homebooks: [] },
    user: { user: {} }
  };

  const combinedReducers = combineReducers({ book : bookReducer, user : userReducer });
  return createStore(combinedReducers, initialState);
}
