import { ACTIONS, BASE_URL } from "../consts";
import $ from 'jquery'

export const addSuggestion = object => {
    return {
        type: ACTIONS.ADD_SUGGESTION,
        data: $.ajax({
            method: 'GET',
            dataType: 'application/json',
            url: BASE_URL + 'suggestion/create'

        })
    }
}