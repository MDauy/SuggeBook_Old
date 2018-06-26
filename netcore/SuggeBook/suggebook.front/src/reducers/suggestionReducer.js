import {ACTIONS} from "../consts"

const initialState = {

};

const suggestionReducer = (state = initialState, action) => {
    switch (action.type) {
        case ACTIONS.ADD_SUGGESTION:
        return {
            ...state,
            suggestions : {
                title : action.payload.title
            }
        }
    }
}

export default suggestionReducer;