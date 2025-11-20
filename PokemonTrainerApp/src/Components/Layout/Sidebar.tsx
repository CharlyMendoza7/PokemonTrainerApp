import { NavLink, useNavigate } from "react-router-dom"
import pokemonLogo from "../../assets/pokemonLogo.svg"
import { FaBook, FaBox, FaCog, FaGamepad, FaHome, FaSignOutAlt } from "react-icons/fa"
import { MdCatchingPokemon } from "react-icons/md"
import '../../styles/sidebar.css'
import { useAuth } from "../Authentication/AuthContext"

type SidebarProps = {
    isOpen: boolean
    setIsOpen: React.Dispatch<React.SetStateAction<boolean>>
}

export const Sidebar = ({ isOpen, setIsOpen }: SidebarProps) => {

    const { logout } = useAuth();
    const navigate = useNavigate();

    return (
        <>
            <button className="sidebar-toggle" onClick={() => setIsOpen(!isOpen)}>
                ☰
            </button>

            <div className={`sidebar ${isOpen ? "open" : ""}`}>
                <div className="sidebar-content">
                    {/* Logo */}
                    <NavLink to="/" className="logo">
                        <h1 className='header'>
                            <img src={pokemonLogo}
                                alt="Pokemon Logo" className='pokemon-logo' />
                            Trainer
                        </h1>
                    </NavLink>

                    {/* Navigation Menu */}
                    <nav className="menu">
                        <NavLink to="/" className="menu-item" onClick={() => setIsOpen(false)}>
                            <FaHome className="icon" /><span>Your Pokémon Team</span>
                        </NavLink>
                        <NavLink to="/storage" className="menu-item" onClick={() => setIsOpen(false)}>
                            <FaBox className="icon" /><span>Pokémon Storage</span>
                        </NavLink>
                        <NavLink to="/pokedex" className="menu-item" onClick={() => setIsOpen(false)}>
                            <MdCatchingPokemon className="icon" /><span>Pokédex</span>
                        </NavLink>
                        <NavLink to="/wiki" className="menu-item" onClick={() => setIsOpen(false)}>
                            <FaBook className="icon" /><span>Wiki</span>
                        </NavLink>
                        <NavLink to="battles" className="menu-item" onClick={() => setIsOpen(false)}>
                            <FaGamepad className="icon" /> <span>Battle Center</span>
                        </NavLink>
                    </nav>
                </div>

                <div className="sidebar-footer">
                    {/* Settings at the bottom */}
                    {/* logout at the bottom */}
                    <NavLink to="/settings" className="menu-item" onClick={() => setIsOpen(false)}>
                        <FaCog className="icon" /><span>Settings</span>
                    </NavLink>

                    <button className="menu-item" onClick={() => {
                        logout();
                        navigate("/login");
                    }}>
                        <FaSignOutAlt className="icon" /><span>Logout</span>
                    </button>
                </div>

            </div>
        </>
    )
}
