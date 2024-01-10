/* eslint-disable react/prop-types */
import axios from "axios";
import { createContext, useEffect, useState } from "react";

export const UserContext = createContext({});

export const UserContextProvider = ({children}) => {

    const [user, setUser] = useState(null);

    useEffect(() => {
        console.log("context")
        if (!user) {
          axios.get('account/profile').then(({data}) =>{
            setUser(data);
          });
        }
      }, []);
    return (
        <UserContext.Provider value={{user, setUser}}>
            {children}
        </UserContext.Provider>
    );
}