import React from 'react'
import { useState } from 'react'
import { useEffect } from 'react'
import { getAllOrders } from '../../Services/PizzaService';
import { Button, Grid, Paper, Typography } from '@mui/material';
import OrderStatusText from '../../components/OrderStatusText/OrderStatusText';
import { useNavigate } from 'react-router-dom';

export default function AllOrdersPage() {

    const [orders, setOrders] = useState([]);
    const navigate = useNavigate();

    async function fetchOrders(filter) {
        try {
            const response = await getAllOrders(0);
            setOrders(response.data);
        }
        catch (e) {
            console.log(e);
        }
    }
    async function selectOrder(order) {
        navigate(`/order/${order.orderId}`, { state: { order: order } });
    }
    useEffect(() => {
        fetchOrders(0)
        console.log(orders);
    }, [])
    return (
        <Grid container spacing={2}>
            {orders.map((order) => (
                <Grid item xs={12} sm={5} sx={{ m: 3 }} key={order.orderId}>
                    <Paper sx={{ p: 2, display: "flex", justifyContent: "space-between" }}>
                        <div>
                            <div>Delivery Address: {order.streetToDelivery}</div>
                            <div>
                                {order.promocode ? (
                                    <Typography color="error">Total cost: {order.finalCost - order.promocode}</Typography>
                                ) : (
                                    <Typography variant="body2" color="textSecondary">
                                        Total cost: {order.finalCost}
                                    </Typography>
                                )}
                            </div>
                        </div>
                        <div>
                            <OrderStatusText statusId={order.status} />
                        </div>
                        <Button onClick={()=>selectOrder(order)}>Select</Button>
                    </Paper>
                </Grid>
            ))}
        </Grid>
    )
}
