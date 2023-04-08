import { Box } from '@mui/material'
import React from 'react'

export default function TotalCostText({cost}) {
  return (
    <li>
    <Box sx={{ display: "flex", alignItems: "center" }}>
        <Box component="span" sx={{ flexGrow: 1 }}>
            Total
        </Box>
        <Box component="span" sx={{ pl: 2 }}>
            ${cost}
        </Box>
    </Box>
</li>
  )
}
