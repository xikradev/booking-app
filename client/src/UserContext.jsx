/* eslint-disable react/prop-types */
import axios from "axios";
import { createContext, useEffect, useState } from "react";

export const UserContext = createContext({});

export const UserContextProvider = ({ children }) => {
  const [ready, setReady] = useState(false)
  const [user, setUser] = useState(null);
  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get('account/profile');
        setUser(response.data);
        setReady(true);
      } catch (error) {
        console.error("Error fetching user data:", error);
        setReady(true);
      }
    };

    if (!user) {
      fetchData();
    }
  }, [user]);

  return (
    <UserContext.Provider value={{ user, setUser, ready }}>
      {children}
    </UserContext.Provider>
  );
}