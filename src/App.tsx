import './App.css';
import pokemonLogo from './assets/pokemonLogo.svg';
import { LoginPage } from './Components/LoginPage';

function App() {

  return (
    <>
      <div className="welcome-container">
        <div className="welcome-box">
          <h1 className='header'><img src={pokemonLogo} alt="Pokemon Logo" className='logo' /> Trainer</h1>
          <LoginPage />
        </div>
      </div>
    </>
  )
}

export default App
