import { Divider, Drawer, List, Grid, ListItem, ListItemIcon, Typography, ListItemText, Button, TextField } from '@mui/material'
import ShoppingBasketIcon from '@mui/icons-material/ShoppingBasket';
import React from 'react'
import CartIListItem from './CartIListIItem'
import { useState } from 'react';
import { getDiscountAmount } from '../../Services/PizzaService';

export default function Cart({ cartOpen, cartClose, cartProduct, removeFromOrder, createOrder, openSnack }) {

    const [promocodeDiscountAmount, setPromocodeDiscountAmount] = useState();
    const [promocode, setPromocode] = useState();
    const [deliveryStreet, setDeliveryStreet] = useState();

    async function applyPromocode() {
        try {
            var result = await getDiscountAmount(promocode);
            setPromocodeDiscountAmount(result.data);
        }
        catch (e) {
            console.log(e);
            openSnack(e.response.data[0])
        }
    }

    return (
        <Drawer
            anchor='right'
            open={cartOpen}
            onClose={cartClose}>
            <List sx={{ width: '400px', height: '100%', position: 'relative' }}>
                <ListItem>
                    <ListItemIcon>
                        <ShoppingBasketIcon />
                    </ListItemIcon>
                    <ListItemText primary="Cart" />
                    <TextField label={'Street to delivery'} onChange={(e) => setDeliveryStreet(e.target.value)} />
                </ListItem>
                <Divider />

                {!cartProduct.length ? (
                    <ListItem>Cart is empty</ListItem>
                ) : (
                    <>
                        {cartProduct.map((product, id) => (
                            <CartIListItem removeFromOrder={removeFromOrder} name={product.name} cost={product.cost} id={product.id} key={id} />
                        ))}
                        <Divider />
                        <Grid container sx={{ position: 'absolute', bottom: 0 }}>
                            <Grid item xs={8} sx={{ textAlign: 'center', margin: '0 auto' }} >
                                <TextField disabled={promocodeDiscountAmount} label={'promocode'} name='promocode' onChange={(e) => setPromocode(e.target.value)} />
                            </Grid>
                            {promocodeDiscountAmount ? (<></>) : (<>
                                <Grid item xs={4}>
                                    <Button onClick={() => applyPromocode()} variant={'contained'} size='small'>
                                        Apply promocode
                                    </Button>
                                </Grid>
                            </>)}
                            <ListItem >
                                <Grid item xs={6}>
                                    <Typography>
                                        Cost: {cartProduct.reduce((acc, curr) => acc + curr.cost, 0)}
                                    </Typography>
                                    {!promocodeDiscountAmount ? (
                                        <></>
                                    ) : (<>
                                        <Typography sx={{ fontWeight: 700 }}>
                                            Total Cost:{' '}
                                            {cartProduct.reduce((acc, curr) => acc + curr.cost, 0) - promocodeDiscountAmount}$.
                                        </Typography>
                                    </>)}
                                </Grid>
                                <Grid item xs={6}>
                                    <Button variant={'contained'} onClick={() => createOrder(cartProduct, promocode, deliveryStreet)}>Create Order</Button>
                                </Grid>
                            </ListItem>
                        </Grid>
                    </>
                )}
            </List>
        </Drawer >
    )
}
