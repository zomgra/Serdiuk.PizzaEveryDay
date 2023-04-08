import { Box } from '@mui/material'
import React from 'react'

export default function ProductOrderItem({product}) {
  return (
    <li >
       <Box sx={{ display: "flex", alignItems: "center" }}>
              <Box component="span" sx={{ flexGrow: 1 }}>
                {product.name} 
              </Box>
              <Box component="span" sx={{ pl: 2 }}>
                ${product.cost}
              </Box>
            </Box>
    </li>
  )
}
