import { useContext, useState } from "react"
import { UserContext } from "../UserContext"
import { Link, Navigate, useParams } from "react-router-dom"
import axios from 'axios'
import PlacesPage from "./PlacesPage"
import ProfileIcon from "/src/assets/profile-icon.png"
import MenuIcon from "/src/assets/menu-icon.png"
import HouseIcon from "/src/assets/house-icon.png"

const AccountPage = () => {
  const { user, setUser, ready} = useContext(UserContext)
  const[redirect, setRedirect] = useState(null)

  let { subpage } = useParams();
  if (subpage === undefined) {
    subpage = 'profile'
  }

  const logout = async () =>{
    axios.post('/account/logout')
    setUser(null);
    setRedirect('/')
  }

  if(!ready){
    return 'Loading...'
  }

  if (ready && !user && !redirect) {
    return <Navigate to={"/login"} />
  }

  const linkClasses = (type = null) => {
    let classes = 'inline-flex gap-3 items-center py-2 px-6';
    if (type === subpage || (subpage === undefined && type === 'profile')) {
      classes += ' bg-blue-900 text-white rounded-full';
    }else{
      classes += ' bg-gray-400 text-white rounded-full'
    }
    return classes
  }

  if(redirect){
    return <Navigate to={redirect}/>
  }

  return (
    <div>
      <nav className="w-full flex justify-center mt-4 gap-2 mb-8">
        <Link className={linkClasses('profile')} to={'/account/profile'}> 
          <img src={ProfileIcon} alt="" />
          My Profile
        </Link>
        <Link className={linkClasses('bookings')} to={'/account/bookings'}>
          <img src={MenuIcon} alt="" className="text-white"/>
          My Bookings
        </Link>
        <Link className={linkClasses('places')} to={'/account/places'}>
          <img src={HouseIcon} alt="" />
          My accommodations
        </Link>
      </nav>
      {subpage === 'profile' && (
        <div className="flex justify-center">
          <div className="text-center p-4 border border-2 border-slate-500 rounded rounded-md bg-slate-50 shadow-xl">
            Logged in as {user.username} ({user.email})
            <br />
            <button onClick={logout} className="py-2 px-6 bg-blue-900 text-white rounded-full max-w-sm mt-2">Logout</button>
          </div>
        </div>
      )}
      {subpage === 'places' && (
        <PlacesPage/>
      )}
    </div>
  )
}

export default AccountPage;