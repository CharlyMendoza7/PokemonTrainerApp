import '../styles/login.css'
import pokemonLogo from '../assets/pokemonLogo.svg';
import { useNavigate } from 'react-router-dom';
import { useEffect, useState } from 'react';
import { useAuth } from './Authentication/AuthContext';


export const LoginPage = () => {

    const navigate = useNavigate();
    const { isAuthenticated, login } = useAuth();

    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('')

    const handleCreateNewAccountClick = () => {
        navigate('/register');
    }

    const fetchUser = async (userName: string, password: string) => {
        try {
            const response = await fetch(`https://localhost:7022/api/PokemonTrainer/getUserLoginAccess?username=${userName}&password=${password}`);

            if (!response.ok) {
                throw new Error("HTTP ERROR MATE");
            }

            const data = await response.json();
            console.log("User info is: ", data);
            return data;
        } catch (error) {
            console.error("Fetch error", error);
            return false;
        }
    }

    const handleLoginClick = async (e: React.FormEvent) => {
        e.preventDefault();
        // console.log(e);
        setError('');

        const result = await fetchUser(username, password);
        console.log("Result from fetchUser: ", result);
        if (!result) {
            console.error("User/password is incorrect");
            setError("User/password is incorrect");
        } else {
            login(result.username, result.token, result.userId, result.role);
        }
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
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                    />
                    <input
                        type="password"
                        placeholder="Password"
                        className='login-input'
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                    {error && <p className='error-message' style={{ color: 'red', textAlign: 'center', marginTop: '1px' }}>{error}</p>}
                    <button
                        type="submit"
                        className='login-button'
                        onClick={handleLoginClick}
                    >
                        Sign in
                    </button>
                    <button
                        type="submit"
                        onClick={handleCreateNewAccountClick}
                        className='register-button'
                    >
                        Create new account
                    </button>
                </form>
            </div>
        </div>
    )
}
