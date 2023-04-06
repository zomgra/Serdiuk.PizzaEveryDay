import React, { useEffect, useState } from 'react'
import { createOrderHandler, getAllProducts } from '../../Services/PizzaService';
import { Alert, Container, Divider, Grid, Snackbar } from '@mui/material';

import PizzaListItem from '../../components/ProtuctsItem/PizzaListItem'
import DrinkListItem from '../../components/ProtuctsItem/DrinkListItem';
import Cart from '../../components/Cart/Cart';
import { Navigate } from 'react-router-dom';

export default function RestaurantPage({ setCartProduct, cartProducts, isCartOpen, setCartOpen, removeFromOrder }) {

    const [products, setProducts] = useState([]);
    const [isSnackOpen, setSnackOpen] = useState();
    const [errorMessage, setErrorMessage] = useState()

    function errorSnack(message) {
        setErrorMessage(message);
        setSnackOpen(true)
    }

    async function createOrder(products, promocode, deliveryStreet) {
        const productIds = products.map((product) => product.id);
        const object = { productsId: productIds, promocode: promocode, streetToDelivery: deliveryStreet }
        console.log(object);
        try {
            var responce = await createOrderHandler(object);
           window.location.href = `/order/${responce.data.orderId}`;
        }
        catch (e) {
            errorMessage(e.response.data)
        }
    }


function addInCart(id, name, cost) {
    console.log(id);
    setCartProduct(cart => [...cart, { id: id, name: name, cost: cost }])
}

useEffect(() => {
    async function getProducts() {
        const products = await getAllProducts();
        setProducts(products);
    }
    getProducts();
}, []);

if (!products || !products.pizzas || !products.drinks) {
    return <div>Loading...</div>;
}

return (
    <Container>
        <Grid sx={{ mt: 2 }} container spacing={3}>
            {products.pizzas.map((pizza) => (
                <PizzaListItem key={pizza.productId} addInCart={addInCart} id={pizza.productId} imageUrl={pizza.imageUrl} name={pizza.name} cost={pizza.cost} ingredients={pizza.ingredients} />
            ))}
        </Grid>
        <Divider variant='middle' sx={{ mt: 4, mb: 4, borderColor: 'gray' }} />
        <Grid sx={{ mt: 2 }} container spacing={3}>
            {products.drinks.map((drink) => (
                <DrinkListItem key={drink.productId} drink={drink} addInCart={addInCart} />
            ))}
        </Grid>
        <Cart removeFromOrder={removeFromOrder} createOrder={createOrder} cartProduct={cartProducts} cartOpen={isCartOpen} openSnack={errorSnack} cartClose={() => setCartOpen(false)} />
        <Snackbar
            variant='primary'
            open={isSnackOpen}
            autoHideDuration={5000}
            message={errorMessage}
            onClose={() => setSnackOpen(false)}
        >
            <Alert severity='error'>{errorMessage}</Alert>
        </Snackbar>
    </Container>
);
}