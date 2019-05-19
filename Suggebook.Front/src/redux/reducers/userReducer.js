import { ACTIONS } from "../../consts";

const userReducer = (state, action) =>
{
    switch (action)
    {
        case ACTIONS.CONNECT_USER:
            return {
                ...state,
                user : state.data
            }
            default:
                return state;
    }
}

export default userReducer;