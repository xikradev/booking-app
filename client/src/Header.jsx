import { useContext } from "react"
import { Link } from "react-router-dom"
import {UserContext} from  './UserContext'
import UserIcon from '/src/assets/user-icon.png'
import MenuImage from '/src/assets/menu.png'
import LogoImage from '/src/assets/booking-logo.png'
import SearchIcon from '/src/assets/search-icon.png'

const Header = () => {
    const {user} = useContext(UserContext)
    return (
        <header className='flex justify-between'>
            <Link to={"/"} className="flex items-center gap-1 p-2 border border-2 border-blue-900 rounded rounded-lg">
                <img src={LogoImage} alt="" className='w-8 h-8' />
                <span className='font-bold text-blue-900 text-xl'>BookSnap</span>
            </Link>
            <div className='flex rounded-full py-2 px-4 border border-gray-300 gap-2 shadow-md shadow-gray-500 items-center'>
                <div>Anywhere</div>
                <div className="border border-l border-gray-300 h-full"></div>
                <div>Any Week</div>
                <div className="border border-l border-gray-300 h-full"></div>
                <div>Add guests</div>
                <button className='bg-blue-900 p-2 w-8 rounded-full'>
                    <img src={SearchIcon} alt="" />
                </button>
            </div>
            <Link to={user ? "/account": "/login"} className='flex rounded-full py-2 px-4 border border-gray-300 gap-2 items-center'>
                <div className='w-6'>
                    <img src={MenuImage} alt="menu" />
                </div>
                <div className='w-6 bg-slate-300 rounded-full'>
                    <img src={UserIcon} alt="usericon" />
                </div>
                {!!user && (
                    user.username
                )}
            </Link>
        </header>
    )
}

export default Header