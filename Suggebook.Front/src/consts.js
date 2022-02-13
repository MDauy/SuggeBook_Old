export const BASE_URL = 'http://localhost:5002/api/';

export const ACTIONS = {
    ADD_SUGGESTION : "ADD_SUGGESTION",
    GET_BOOK : "GET_BOOK",
    GET_HOME_BOOKS:"GET_HOME_BOOKS",
    CONNECT_USER : "CONNECT_USER"
}

export const URLS = {
    GET_BOOK : BASE_URL + "book/",
    GET_HOME_BOOKS : BASE_URL + "book/home-items"
}