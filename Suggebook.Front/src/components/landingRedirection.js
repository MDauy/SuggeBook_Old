import {React} from 'react'
import HomeBooksContainer from './book/homeBooksContainer'
import LoginForm from './user/loginForm'
import {connect} from 'react-redux'
class LandingRedirection extends React.Component
{
constructor (props)
{
    super (props);
    this.state = {
        user : {}
    }
}

render ()
{
    
        if (this.user && this.user.isLoggedIn)
        {
            return (<HomeBooksContainer></HomeBooksContainer>);
        }
        else
        {
            return (<LoginForm></LoginForm>)
        }
    
}
}

function mapStateToProps (state)
{
    return{
        user : state.user
    };
}

export default connect (mapStateToProps, null)(LandingRedirection);