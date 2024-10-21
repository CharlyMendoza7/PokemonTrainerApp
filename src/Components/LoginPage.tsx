import '../styles/login.css'

export const LoginPage = () => {



    return (
        <div>
            <form className="login-form">
                <input
                    type="text"
                    placeholder="Username"
                    className='login-input'
                />
                <input
                    type="password"
                    placeholder="Password"
                    className='login-input'
                />
                <button type="submit" className='login-button'>Sign in</button>
            </form>
        </div>
    )
}
