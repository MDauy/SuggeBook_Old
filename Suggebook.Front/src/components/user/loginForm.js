import {React} from 'react'
import {connectUser} from '../../redux/actions/userActions'
import {connect} from 'react-redux'
class LoginForm extends React.Component{
    constructor (props)
    {
        super (props);
        this.state = {
            username : '',
            mail : '',
            password :'',
            favorite_categories : []
        }
    }

    onUsernameChange (event)
    {

    }

    onSecondPasswordCompleted(event)
    {

    }

    onSubmit(event)
    {

    }
    

    render (){
    return (
        <form class="form-container" id="login-form">
            <div class="form-group">
                <label for="mail-input">Mail ou pseudo</label>
                <input class="form-control" id="mail-input" type="text"></input>
            </div>
            <div class="form-group">
                <label for="password-input"></label>
                <input class="form-control" id="password-input" type="password"></input>
            </div>
        </form>
    );
    }
}

function mapDispatchToProps (dispatch) {
        return {
            connectUser : (user) => connectUser (user, dispatch) 
        }
}

export default connect (null, mapDispatchToProps)(LoginForm)