import React, { useEffect, useState } from 'react'
import { userManager } from '../../Services/AuthService'
import { Navigate, Outlet } from 'react-router-dom';
import Header from '../../components/Header';

export default function PrivateRouter() {
    const [isAuth, setAuthorize] = useState( false);
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
      async function setAuth() {
  
          var user = await userManager.getUser();
          console.log(user);
          const isAuth = user !== null && !user.expired;
          await setAuthorize(isAuth)
          await setIsLoading(false);
        }
        setAuth();
      }, [])
    
      if (isLoading) {
        return <div>Loading...</div>;
      }
      else {
        return (
            <>
            {isAuth ? <Outlet /> : <Navigate to="/login" />}
            </>
        )
      }
}
