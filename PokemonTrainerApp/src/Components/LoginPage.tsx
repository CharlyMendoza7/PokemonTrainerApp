import '../styles/login.css'
import pokemonLogo from '../assets/pokemonLogo.svg';
import { useNavigate } from 'react-router-dom';
import { useEffect } from 'react';
import { useAuth } from './Authentication/AuthContext';


export const LoginPage = () => {

    const navigate = useNavigate();
    const { isAuthenticated, login } = useAuth();

    const handleCreateNewAccountClick = () => {
        navigate('/register');
    }

    useEffect(() => {
        if (isAuthenticated) {
            navigate('/', { replace: true })
        }
    }, [isAuthenticated, navigate])

    return (
        <div className="welcome-container">
            <div className="welcome-box">
                <h1 className='header'><img src={pokemonLogo} alt="Pokemon Logo" className='logo' /> Trainer</h1>
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
                    <button
                        type="submit"
                        onClick={handleCreateNewAccountClick}
                        className='register-button'>Create new account</button>
                </form>
            </div>
        </div>
    )
}
