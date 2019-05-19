
import {ACTIONS, BASE_URL} from "../../consts"
export const getBook = (id, dispatch)=> {
    return fetch (BASE_URL + 'book/' + id)
    .then(response => response.json())
    .then(json => dispatch(resolvedCall(json, ACTIONS.GET_BOOK)))
}

export const getHomeBooks = (dispatch) => {
    return fetch (BASE_URL + 'book/home')
    .then(
        response => response.json()
        )
    .then(
        json => dispatch(resolvedCall(json, ACTIONS.GET_HOME_BOOKS)
        ));

}

export const resolvedCall = (data, actionType) => {
    return {
        type:actionType,
        data : data
    }
}