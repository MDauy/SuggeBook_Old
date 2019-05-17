import $ from 'jquery'
import {ACTIONS, BASE_URL} from "../../consts"
export const getBook = (id)=> {
    return {
        type: ACTIONS.GET_BOOK,
        data: $.ajax({
            method: 'GET',
            dataType: 'application/json',
            url: BASE_URL + 'book/' + id

        })
    }
}

export const getHomeBooks = () => {
    return {
        type:ACTIONS.GET_HOME_BOOKS,
        data : $.ajax ({
            method:"GET",
            dataType:"application/json",
            url:BASE_URL + "book/home"
        })
    }

}