import { AppBar, Badge, IconButton, Toolbar, Typography } from '@mui/material'
import ShoppingBasketIcon from '@mui/icons-material/ShoppingBasket';
import React from 'react'
import BorderAllIcon from '@mui/icons-material/BorderAll';
import { userManager } from '../Services/AuthService';
import { Link, useNavigate } from 'react-router-dom';

export default function Header({ cartProduct, handleCart }) {

    const isAuth = userManager.getUser();
    const navigate = useNavigate()

    return (
        <AppBar color='neutral' enableColorOnDark position='static' >
            <Toolbar >
                <Typography
                    sx={{ flexGrow: 1 }}
                    variant='h6'
                    component='span'
                >
                    <Link to="/restaurant" >
                        Pizza Every Day
                    </Link>
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
                {isAuth && (
                    <IconButton
                        onClick={() => navigate('/orders')}>
                        <BorderAllIcon />
                    </IconButton>
                )}
            </Toolbar>
        </AppBar >
    )
}
