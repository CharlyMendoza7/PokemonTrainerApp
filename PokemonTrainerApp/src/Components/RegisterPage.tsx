import { Link, useNavigate } from 'react-router-dom';
import '../styles/register.css';
import { useEffect, useState } from 'react';
import { useAuth } from './Authentication/AuthContext';
import { RegisterModel } from './AppTypes';



export const RegisterPage = () => {

    const navigate = useNavigate();

    const { login, isAuthenticated } = useAuth();

    const [formData, setFormData] = useState({
        firstName: '',
        lastName: '',
        birthDate: '',
        gender: '',
        userName: '',
        email: '',
        password: '',
        confirmPassword: '',
    });

    useEffect(() => {
        if (isAuthenticated) {
            navigate('/', { replace: true })
        }
    }, [isAuthenticated, navigate])


    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        const { name, value } = e.target;

        setFormData({
            ...formData,
            [name]: value
        });
    }

    const registerUser = async (model: RegisterModel) => {
        try {
            const response = await fetch("http://localhost:7032/api/PokemonTrainer/registerNewUser", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(model),
            });

            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }

            const result = await response.json();
            console.log("User registered successfully: ", result);

            return result;
        } catch (error) {
            console.error("Error registering user: ", error);
        }

    }


    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        if (formData.password !== formData.confirmPassword) {
            console.error("Passwords do not match");
            return;
        }

        try {
            const userModel: RegisterModel = {
                firstName: formData.firstName,
                lastName: formData.lastName,
                birth: new Date(formData.birthDate),
                userName: formData.userName,
                gender: formData.gender,
                email: formData.email,
                password: formData.password
            }

            const result = await registerUser(userModel);

            if (result) {
                console.log("Registration successful, logging in...");
                login(formData.userName);
                navigate("/"); //check this
            } else {
                console.error("Registration failed.")
            }
        } catch (error) {
            console.error("Error during registration:", error);
        }

    }

    const today = new Date();
    const minDate = new Date(today.getFullYear() - 6, today.getMonth(), today.getDate());

    const minDateString = minDate.toISOString().split('T')[0];

    return (
        <div className="register-container">
            <div className='register-box'>
                <h1 className='register-title'>Create New Account</h1>
                <form onSubmit={handleSubmit}>
                    <div className='form-group'>
                        <label>First Name</label>
                        <input
                            type='text'
                            name='firstName'
                            value={formData.firstName}
                            onChange={handleChange}
                            required
                        />
                    </div>
                    <div className='form-group'>
                        <label>Last Name</label>
                        <input
                            type='text'
                            name='lastName'
                            value={formData.lastName}
                            onChange={handleChange}
                        // required
                        />
                    </div>
                    <div className='form-group'>
                        <label>Date of Birth</label>
                        <input
                            type='date'
                            name='birthDate'
                            value={formData.birthDate}
                            onChange={handleChange}
                            max={minDateString} //Restriction to 6 years or older
                        // required
                        />
                    </div>
                    <div className='form-group'>
                        <label>Gender</label>
                        <select
                            name='gender'
                            value={formData.gender}
                            onChange={handleChange}
                        // required
                        >
                            <option value="">Select Gender</option>
                            <option value="male">Male</option>
                            <option value="female">Female</option>
                            <option value="other">Other</option>
                        </select>
                    </div>
                    <div className='form-group'>
                        <label>Username</label>
                        <input
                            type='text'
                            name='userName'
                            value={formData.userName}
                            onChange={handleChange}
                            required
                        />
                    </div>
                    <div className='form-group'>
                        <label>Email</label>
                        <input
                            type='email'
                            name='email'
                            value={formData.email}
                            onChange={handleChange}
                        // required
                        />
                    </div>
                    <div className='form-group'>
                        <label>Password</label>
                        <input
                            type='password'
                            name='password'
                            value={formData.password}
                            onChange={handleChange}
                        // required
                        />
                    </div>
                    <div className='form-group'>
                        <label>Confirm Password</label>
                        <input
                            type='password'
                            name='confirmPassword'
                            value={formData.confirmPassword}
                            onChange={handleChange}
                        // required
                        />
                    </div>
                    <button type='submit'>Register</button>
                </form>
                <p>Already have an account? <Link to='/login'>Log in here</Link></p>
            </div>
        </div>
    )
}
