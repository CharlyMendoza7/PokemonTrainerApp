import '../styles/login.css'
import pokemonLogo from '../assets/pokemonLogo.svg';
import { useNavigate } from 'react-router-dom';
import { useEffect, useState } from 'react';
import { useAuth } from './Authentication/AuthContext';


export const LoginPage = () => {

    const navigate = useNavigate();
    const { isAuthenticated, login } = useAuth();

    const [first, setfirst] = useState([])

    const handleCreateNewAccountClick = () => {
        navigate('/register');
    }

    const fetchUser = async () => {
        try {
            const response = await fetch("https://localhost:7032/api/PokemonTrainer/getUsers");

            if (!response.ok) {
                throw new Error("HTTP ERROR MATE");
            }

            const data = await response.json();
            console.log("User info is: ", data);
        } catch (error) {
            console.error("Again mate error fetch", error)
        }
    }

    const handleLoginClick = (e: React.FormEvent) => {
        e.preventDefault();
        const x = fetchUser();
        // setfirst([...first, x]);
        console.log(x);
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
                <h2>{first}</h2>
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
