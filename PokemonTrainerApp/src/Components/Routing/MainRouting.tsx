import { Navigate, Route, Routes } from "react-router-dom"
import { LoginPage } from "../LoginPage"
import { RegisterPage } from "../RegisterPage"
import { PrivateRoute } from "./PrivateRoute"
import { HomePage } from "../HomePage"
import { useAuth } from "../Authentication/AuthContext"

export const MainRouting = () => {

    const { isAuthenticated } = useAuth();

    return (
        <Routes>
            {/* Public routes */}
            <Route path="/login" element={<LoginPage />} />
            <Route path="/register" element={<RegisterPage />} />

            {/* Protected Routes */}
            <Route element={<PrivateRoute />}>
                <Route path='/home' element={<HomePage />} />
            </Route>

            <Route
                path='/*'
                element={
                    isAuthenticated ? <Navigate to="/home" /> : <Navigate to="/login" />
                }
            />

        </Routes>
    )
}
