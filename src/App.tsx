import { BrowserRouter } from 'react-router-dom';

import './App.css';
import { AuthProvider } from './Components/Authentication/AuthContext';
import { MainRouting } from './Components/Routing/MainRouting';

function App() {


  return (
    <>
      <BrowserRouter>
        <AuthProvider>
          <MainRouting />
        </AuthProvider>
      </BrowserRouter>
    </>
  )
}

export default App
