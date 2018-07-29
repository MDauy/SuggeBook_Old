import {ACTIONS} from "../consts";

export const addSuggestion = object => {
    return  {
        type : ACTIONS.ADD_SUGGESTION,
        payload : {
            title : object.title
        }
    }
}