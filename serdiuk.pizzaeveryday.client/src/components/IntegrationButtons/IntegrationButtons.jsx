import { Box, Button } from '@mui/material'
import React from 'react'


export default function IntegrationButtons({statusId, payHandler, cancelHandler}) {

    const viewPayButton = statusId === 0;
    const viewCancelButton = statusId === 0 || statusId === 1;

    return (
        <Box sx={{ mt: 2, display: "flex", justifyContent: "space-between" }}>
            {viewPayButton &&(
                <Button variant="contained" onClick={payHandler} color='success' sx={{ width: "40%" }}>Pay</Button>
            )}
            {viewCancelButton && (
                <Button variant="contained" onClick={cancelHandler} color='error' sx={{ width: "40%" }}>Cancel</Button>
            )}
        </Box>
    )
}
