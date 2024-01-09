/* eslint-disable react/prop-types */
import axios from "axios";
import { createContext, useEffect, useState } from "react";

export const UserContext = createContext({});

export const UserContextProvider = ({children}) => {

    const [user, setUser] = useState(null);
    useEffect(() =>{
        if(!user){
            axios.get("/profile").then(({data}) =>{
                setUser(data);
                console.log(`/profile: ${data}`);
            });
        }
    },[])

    return (
        <UserContext.Provider value={{user, setUser}}>
            {children}
        </UserContext.Provider>
    );
}