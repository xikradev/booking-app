import { useState, useContext } from "react"
import { Link, Navigate } from "react-router-dom"
import axios from "axios";
import {UserContext} from '../UserContext'

const LoginPage = () => {

    const[email, setEmail] = useState('');
    const[password, setPassword] = useState('');
    const[redirect, setRedirect] = useState(false);
    const {setUser} = useContext(UserContext);

    const handleLoginSubmit = async (e) => {
        e.preventDefault();
       
        try{
            const {data} = await axios.post('/account/login', {email, password})
            setUser(data)
            console.log(`/login ${data}`)
            alert('login successsful')
            setRedirect(true)
        }catch(e){
            alert('login failed')
        }
    }

    if(redirect){
        return <Navigate to={'/'}/>
    }

    return (
        <div className="mt-4 grow flex items-center justify-around">
            <div className="mb-64">
                <h1 className="text-4xl text-center">Login</h1>
                <form className="max-w-md mx-auto" onSubmit={handleLoginSubmit}>
                    <input type="email" placeholder="your@email.com" value={email} onChange={(e) => setEmail(e.target.value)}/>
                    <input type="password" placeholder="password" value={password} onChange={(e) => setPassword(e.target.value)}/>
                    <button className="primary">Login</button>
                    <div className="text-center py-2 text-gray-500">
                        Don&apos;t have an account yet?
                        <Link className='underline text-black' to={"/register"}>Register now</Link>
                    </div>
                </form>
            </div>
        </div>
    )
}

export default LoginPage