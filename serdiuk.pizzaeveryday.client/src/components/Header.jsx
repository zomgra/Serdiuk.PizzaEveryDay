import { AppBar, Badge, IconButton, Toolbar, Typography } from '@mui/material'
import ShoppingBasketIcon from '@mui/icons-material/ShoppingBasket';
import React from 'react'

export default function Header({ cartProduct, handleCart }) {
    return (
        <AppBar color='neutral' enableColorOnDark position='static' >
            <Toolbar >
                <Typography
                    sx={{ flexGrow: 1 }}
                    variant='h6'
                    component='span'
                >
                    Pizza Every Day
                </Typography>
                <IconButton
                    onClick={(e) => {
                        e.stopPropagation();
                        handleCart();
                    }
                    }>
                    <Badge badgeContent={cartProduct.length} color='secondary' >
                        <ShoppingBasketIcon />
                    </Badge>
                </IconButton>
            </Toolbar>
        </AppBar >
    )
}
