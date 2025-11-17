import { Navigate, Route, Routes } from "react-router-dom"
import { LoginPage } from "../LoginPage"
import { RegisterPage } from "../RegisterPage"
import { PrivateRoute } from "./PrivateRoute"
import { HomePage } from "../HomePage"
import { useAuth } from "../Authentication/AuthContext"
import { Sidebar } from "../Layout/Sidebar"
import { PokedexPage } from "../Pokedex/PokedexPage"
import { ProfilePage } from "../Profile/ProfilePage"

export const MainRouting = () => {

    const { isAuthenticated, isAuthLoading } = useAuth();

    console.log('Main Routing: ', { isAuthenticated, isAuthLoading })
    if (isAuthLoading) return <div>Loading...</div>

    return (
        <div className="app-layout">
            {isAuthenticated && <Sidebar />}
            <div className="main-content">
                <Routes>
                    {/* Public routes */}
                    <Route path="/login" element={<LoginPage />} />
                    <Route path="/register" element={<RegisterPage />} />

                    {/* Protected Routes */}
                    <Route element={<PrivateRoute />}>
                        <Route path='/home' element={<HomePage />} />
                        <Route path='/pokedex' element={<PokedexPage />} />
                        <Route path='/profile' element={<ProfilePage />} />
                    </Route>

                    <Route
                        path='/*'
                        element={
                            isAuthenticated ? <Navigate to="/home" /> : <Navigate to="/login" />
                        }
                    />

                </Routes>
            </div>
        </div>
    )
}
