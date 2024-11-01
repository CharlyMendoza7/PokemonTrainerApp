import { BrowserRouter, Navigate, Route, Routes } from 'react-router-dom';
import { LoginPage } from './Components/LoginPage';

import './App.css';
import { RegisterPage } from './Components/RegisterPage';
import { PrivateRoute } from './Components/PrivateRoute';
import { HomePage } from './Components/HomePage';
import { AuthProvider } from './Components/Authentication/AuthContext';

function App() {

  const isAuthenticated = localStorage.getItem("isAuthenticated") == 'true';

  //Create routing pagecomponent to add the logic there
  return (
    <>
      <BrowserRouter>
        <AuthProvider>
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
        </AuthProvider>
      </BrowserRouter>
    </>
  )
}

export default App
