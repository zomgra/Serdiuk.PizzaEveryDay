import React, { useEffect, useState } from 'react'
import { getAllProducts } from '../../Services/PizzaService';
import { Container, Divider, Grid } from '@mui/material';
import PizzaListItem from '../../components/ProtuctsItem/PizzaListItem'
import DrinkListItem from '../../components/ProtuctsItem/DrinkListItem';
import Cart from '../../components/Cart/Cart';

export default function RestaurantPage({ setCartProduct, cartProducts, isCartOpen, setCartOpen, removeFromOrder }) {

    const [products, setProducts] = useState([]);


    function addInCart(id,name, cost) {
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
                    <PizzaListItem key={pizza.productId} addInCart={addInCart} id={pizza.id} imageUrl={pizza.imageUrl} name={pizza.name} cost={pizza.cost} ingredients={pizza.ingredients} />
                ))}
            </Grid>
            <Divider variant='middle' sx={{ mt: 4, mb: 4, borderColor: 'gray' }} />
            <Grid sx={{ mt: 2 }} container spacing={3}>
                {products.drinks.map((drink) => (
                    <DrinkListItem key={drink.productId} drink={drink} addInCart={addInCart} />
                ))}
            </Grid>
            <Cart removeFromOrder={removeFromOrder} cartProduct={cartProducts} cartOpen={isCartOpen} cartClose={() => setCartOpen(false)} />
        </Container>
    );
}