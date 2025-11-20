import { Navigate, Route, Routes } from "react-router-dom"
import { LoginPage } from "../LoginPage"
import { RegisterPage } from "../RegisterPage"
import { PrivateRoute } from "./PrivateRoute"
import { HomePage } from "../HomePage"
import { useAuth } from "../Authentication/AuthContext"
import { Sidebar } from "../Layout/Sidebar"
import { PokedexPage } from "../Pokedex/PokedexPage"
import { ProfilePage } from "../Profile/ProfilePage"
import { useState } from "react"

export const MainRouting = () => {

    const { isAuthenticated, isAuthLoading } = useAuth();
    const [sidebarOpen, setSideBarOpen] = useState(false);

    console.log('Main Routing: ', { isAuthenticated, isAuthLoading })
    if (isAuthLoading) return <div>Loading...</div>

    return (
        <div className="app-layout">
            {isAuthenticated && <Sidebar isOpen={sidebarOpen} setIsOpen={setSideBarOpen} />}
            {isAuthenticated && sidebarOpen && (
                <div className={`sidebar-overlay ${sidebarOpen ? "" : "hide"}`}
                    onClick={() => setSideBarOpen(false)}
                />
            )}
            <div className={`main-content ${sidebarOpen ? "sidebar-open" : ""}`}>
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
