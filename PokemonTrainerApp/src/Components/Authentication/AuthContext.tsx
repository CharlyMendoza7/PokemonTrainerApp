import { createContext, useContext, useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

interface AuthContextType {
    isAuthenticated: boolean;
    isAuthLoading: boolean;
    login: (username: string, token: string, userId: number, role: string) => void;
    logout: () => void;
    user: string | null;
    token: string | null;
    userId: number | null;
    role: string | null;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const AuthProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {

    const [user, setUser] = useState<string | null>(null);
    const [token, setToken] = useState<string | null>(null);
    const [userId, setUserId] = useState<number | null>(null);
    const [role, setRole] = useState<string | null>(null);

    const [isAuthLoading, setIsAuthLoading] = useState(true);

    const navigate = useNavigate();

    const isAuthenticated = !!token;

    const login = (username: string, jwt: string, id: number, role?: string) => {
        //TODO: set variables in object better????
        setUser(username);
        setToken(jwt);
        setUserId(id);
        setRole(role ?? null);
        localStorage.setItem('jwt', jwt);
        localStorage.setItem('username', username);
        localStorage.setItem('userId', id.toString());
        localStorage.setItem('role', role ?? '');

        navigate('/');
    };

    const logout = () => {
        localStorage.clear()
        setUser(null);
        setToken(null);
        setUserId(null);
        setRole(null);

        navigate('/login');
    }

    useEffect(() => {
        //TODO: CHANGE KEYS TO CONSTANTS, LIKE ENUMS
        const jwt = localStorage.getItem('jwt');
        const username = localStorage.getItem('username');
        const id = localStorage.getItem('userId');
        const storedRole = localStorage.getItem('role');

        console.log('Restore auth: ', { jwt, username, id, storedRole });

        if (jwt && username && id) {
            setUser(username);
            setToken(jwt);
            setUserId(parseInt(id));
            setRole(storedRole || null);
        }

        setIsAuthLoading(false);

    }, [])


    return (
        <AuthContext.Provider value={{ isAuthenticated, login, logout, user, token, userId, role, isAuthLoading }}>
            {children}
        </AuthContext.Provider>
    )

}

export const useAuth = (): AuthContextType => {
    const context = useContext(AuthContext);
    if (!context) throw new Error('useAuth must be used within an AuthProvider')
    return context;
}

