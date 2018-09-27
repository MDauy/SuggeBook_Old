import {ACTIONS} from "../consts";
import $ from 'jquery'

export const addSuggestion = object => {
    return  {
        type : ACTIONS.ADD_SUGGESTION,
        data : $.ajax({
            method:'GET',
            dataType:'application/json',
            url:'http://localhost:5022/testData/'

        })
        }
    }
}