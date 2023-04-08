import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom';
import { createOrderHandler, getAllProducts } from '../../Services/PizzaService';
import { Alert, Container, Divider, Grid, Snackbar } from '@mui/material';

import PizzaListItem from '../../components/ProtuctsItem/PizzaListItem'
import DrinkListItem from '../../components/ProtuctsItem/DrinkListItem';
import Cart from '../../components/Cart/Cart';
import SauceListItem from '../../components/ProtuctsItem/SauceListItem';

export default function RestaurantPage({ setCartProduct, cartProducts, isCartOpen, setCartOpen, removeFromOrder }) {

    const [products, setProducts] = useState([]);
    const [isSnackOpen, setSnackOpen] = useState();
    const [errorMessage, setErrorMessage] = useState()

    const navigate = useNavigate();

    function errorSnack(message) {
        setErrorMessage(message);
        setSnackOpen(true)
    }

    async function createOrder(products, promocode, deliveryStreet) {

        if(!deliveryStreet){
            errorSnack("Street is empty")
            return;
        }

        const productIds = products.map((product) => product.id);
        const object = { productsId: productIds, promocode: promocode, streetToDelivery: deliveryStreet }
        console.log(object);
        try {
            var responce = await createOrderHandler(object);
            navigate(`/order/${responce.data.orderId}`, { state: { order: responce.data } });
        }
        catch (e) {
            errorSnack(e.response.data)
        }
    }


function addInCart(id, name, cost) {
    console.log({id,name,cost});
    setCartProduct(cart => [...cart, { id: id, name: name, cost: cost }])
}

useEffect(() => {
    async function getProducts() {
        const products = await getAllProducts();
        setProducts(products);
        console.log(products);
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
        <Divider variant='middle' sx={{ mt: 4, mb: 4, borderColor: 'gray' }} />
        <Grid sx={{ mt: 2 }} container spacing={3}>
            {products.sauces.map((sauce)=>(
                <SauceListItem key={sauce.productId} addInCart={addInCart} name={sauce.name} cost={sauce.cost} tasty={sauce.taste} id={sauce.productId} imageUrl={sauce.imageUrl}/>
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