import { ACTIONS } from "../consts";

const bookReducer = (state, action)=>
{
    switch(action.type)
    {
        case ACTIONS.GET_BOOK:
        return {
            ...state,
            book : {
                title : action.payload.title
            }
        }
        case ACTIONS.GET_HOME_BOOKS:
        default:
        return {
            ...state,
            homeBooks : [action.payload]
        }
    }
}

export default bookReducer;