import { Link, useNavigate } from 'react-router-dom';
import '../styles/register.css';
import { useEffect, useState } from 'react';
import { useAuth } from './Authentication/AuthContext';



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

    // const registerUser = async (formData)


    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        login(formData.userName)

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
