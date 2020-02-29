import { ACTIONS } from "../../consts";

const bookReducer = (state, action)=>
{
    switch(action.type)
    {
        case ACTIONS.GET_BOOK:
        return {
            ...state,
            book : {
                title : action.data
            }
        }
        case ACTIONS.GET_HOME_BOOKS:        
        return {
            ...state,
            homeBooks : action.data
        }
        default:
        return state;
    }
}

export default bookReducer;