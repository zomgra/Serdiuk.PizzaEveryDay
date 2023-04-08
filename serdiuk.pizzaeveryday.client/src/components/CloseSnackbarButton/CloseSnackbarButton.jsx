import { Button } from '@mui/material'
import React from 'react'

export default function CloseSnackbarButton({action, text}) {
  return (
    <Button onClick={action}>
        {text}
    </Button>
  )
}
