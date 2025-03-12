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
                <NavLink to="/">
                    <FaHome /><span>Your Pokémon Team</span>
                </NavLink>
                <NavLink to="/storage">
                    <FaBox /><span>Pokémon Storage</span>
                </NavLink>
                <NavLink to="/pokedex">
                    <MdCatchingPokemon /><span>Pokédex</span>
                </NavLink>
                <NavLink to="/wiki">
                    <FaBook /><span>Wiki</span>
                </NavLink>
                <NavLink to="battles">
                    <FaGamepad /> <span>Battle Center</span>
                </NavLink>
            </nav>

            {/* Settings at the bottom */}
            <div>
                <NavLink to="/settings">
                    <FaCog /><span>Settings</span>
                </NavLink>
            </div>
        </div>
    )
}
