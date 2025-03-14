import { NavLink } from "react-router-dom"
import pokemonLogo from "../../assets/pokemonLogo.svg"
import { FaBook, FaBox, FaCog, FaGamepad, FaHome } from "react-icons/fa"
import { MdCatchingPokemon } from "react-icons/md"
import '../../styles/sidebar.css'

export const Sidebar = () => {
    return (
        <div className="sidebar">
            {/* Logo */}
            <NavLink to="/" className="logo">
                <h1 className='header'>
                    <img src={pokemonLogo}
                        alt="Pokemon Logo" className='logo' />
                    Trainer
                </h1>
            </NavLink>

            {/* Navigation Menu */}
            <nav className="menu">
                <NavLink to="/" className="menu-item">
                    <FaHome className="icon" /><span>Your Pokémon Team</span>
                </NavLink>
                <NavLink to="/storage" className="menu-item">
                    <FaBox className="icon" /><span>Pokémon Storage</span>
                </NavLink>
                <NavLink to="/pokedex" className="menu-item">
                    <MdCatchingPokemon className="icon" /><span>Pokédex</span>
                </NavLink>
                <NavLink to="/wiki" className="menu-item">
                    <FaBook className="icon" /><span>Wiki</span>
                </NavLink>
                <NavLink to="battles" className="menu-item">
                    <FaGamepad className="icon" /> <span>Battle Center</span>
                </NavLink>
            </nav>

            {/* Settings at the bottom */}
            <div className="menu-bottom">
                <NavLink to="/settings" className="menu-item">
                    <FaCog className="icon" /><span>Settings</span>
                </NavLink>
            </div>
        </div>
    )
}
