import { Divider, Drawer, List, ListItem, ListItemIcon, Typography, ListItemText } from '@mui/material'
import ShoppingBasketIcon from '@mui/icons-material/ShoppingBasket';
import React from 'react'
import CartIListItem from './CartIListIItem'

export default function Cart({ cartOpen, cartClose, cartProduct, removeFromOrder, createOrder }) {

    return (
        <Drawer
            anchor='right'
            open={cartOpen}
            onClose={cartClose}>
            <List sx={{ width: '400px' }}>
                <ListItem>
                    <ListItemIcon>
                        <ShoppingBasketIcon />
                    </ListItemIcon>
                    <ListItemText primary="Cart" />
                </ListItem>
                <Divider />

                {!cartProduct.length ? (
                    <ListItem>Cart is empty</ListItem>
                ) : (
                    <>
                    {console.log(cartProduct)}
                        {cartProduct.map((product, id) => (
                            <CartIListItem removeFromOrder={removeFromOrder} name={product.name} cost={product.cost} id={product.id} key={id} />
                        ))}
                        <Divider />
                        <ListItem>
                            <Typography sx={{ fontWeight: 700 }}>
                                Total Cost:{' '}
                               {cartProduct.reduce((acc, curr) => acc+curr.cost,0)}
                                $.
                            </Typography>
                        </ListItem>
                    </>
                )}
            </List>
        </Drawer>
    )
}
