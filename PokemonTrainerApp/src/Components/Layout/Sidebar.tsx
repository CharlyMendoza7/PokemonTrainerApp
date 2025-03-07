import { NavLink } from "react-router-dom"
import pokemonLogo from "../../assets/pokemonLogo.svg"

export const Sidebar = () => {
    return (
        <div>
            {/* Logo */}
            <NavLink to="/" className="logo">
                <h1 className='header'>
                    <img src={pokemonLogo}
                        alt="Pokemon Logo" className='logo' />
                    Trainer NAV
                </h1>
            </NavLink>
        </div>
    )
}
