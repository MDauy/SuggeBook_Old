import { ACTIONS, BASE_URL } from "../../consts";

export const connectUser = (user, dispatch) => {
    // return postData (BASE_URL + "user/connect", user)
    // .then (response => response.json())
    // .then (json => dispatch(resolvedCall(json, ACTIONS.CONNECT_USER)))
}

export const resolvedCall = (data, actionType) => {
    return {
        type:actionType,
        data : data
    }
}