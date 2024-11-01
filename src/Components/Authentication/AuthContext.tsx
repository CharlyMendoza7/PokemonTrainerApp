import { createContext, useContext, useState } from "react";
import { useNavigate } from "react-router-dom";

interface AuthContextType {
    isAuthenticated: boolean;
    login: (username: string) => void;
    logout: () => void;
    user: string | null;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const AuthProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {

    const [isAuthenticated, setIsAuthenticated] = useState<boolean>(
        () => localStorage.getItem('isAuthenticated') === 'true'
    );
    const [user, setUser] = useState<string | null>(
        () => localStorage.getItem('user')
    );
    const navigate = useNavigate();

    const login = (username: string) => {
        setIsAuthenticated(true);
        localStorage.setItem('isAuthenticated', 'true');
        localStorage.setItem('user', username);
        setUser(username);
        navigate('/');
    };

    const logout = () => {
        setIsAuthenticated(false);
        setUser(null);
        navigate('/login');
    }

    return (
        <AuthContext.Provider value={{ isAuthenticated, login, logout, user }}>
            {children}
        </AuthContext.Provider>
    )

}

export const useAuth = (): AuthContextType => {
    const context = useContext(AuthContext);
    if (!context) throw new Error('useAuth must be used within an AuthProvider')
    return context;
}

