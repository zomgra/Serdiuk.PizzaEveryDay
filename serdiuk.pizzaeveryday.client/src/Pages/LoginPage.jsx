import { Button } from '@mui/material'
import React, { useEffect } from 'react'
import { userManager } from '../Services/AuthService'

export default function LoginPage() {
  return (
    <div>
      <Button onClick={() => { userManager.signinRedirect() }} variant='contained'>Login</Button>
    </div>
  )
}
