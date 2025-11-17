import { Navigate, Outlet } from "react-router-dom";
import { useAuth } from "../Authentication/AuthContext";


export const PrivateRoute = () => {

    const { isAuthenticated, isAuthLoading } = useAuth();

    console.log('Private Route: ', { isAuthenticated, isAuthLoading })

    if (isAuthLoading) {
        return <div>Loading...</div>
    }

    return isAuthenticated ? <Outlet /> : <Navigate to="/login" replace />
}
