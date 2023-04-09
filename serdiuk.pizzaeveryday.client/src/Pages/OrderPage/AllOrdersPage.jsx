import React from 'react'
import { useState } from 'react'
import { useEffect } from 'react'
import { getAllOrders } from '../../Services/PizzaService';
import { Button, Grid, Snackbar, Paper, Typography } from '@mui/material';
import CloseSnackbarButton from '../../components/CloseSnackbarButton/CloseSnackbarButton';
import OrderStatusText from '../../components/OrderStatusText/OrderStatusText';
import { useNavigate } from 'react-router-dom';
import OrderStatusFilterItems from '../../components/OrderStatusFilterItems/OrderStatusFilterItems';
import FinalCostOrder from '../../components/FinalCostOrder/FinalCostOrder';

export default function AllOrdersPage() {

    const [orders, setOrders] = useState([]);
    const [selectStatus, setSelectStatus] = useState(0);
    const [snackSetting, setSnackSetting] = useState({ snackOpen: false, snackMessage: '' })

    const navigate = useNavigate();

    function snackHandler(message) {
        setSnackSetting({ snackOpen: true, snackMessage: message });
    }

    async function changeOrderFilter(status){
        setSelectStatus(status)
        await fetchOrders(status);
    }

    async function fetchOrders(filter) {
        try {
            const response = await getAllOrders(filter);
            setOrders(response.data);
            console.log(orders);
        }
        catch (e) {
            snackHandler(e.response.data);
        }
    }
    async function selectOrder(order) {
        navigate(`/order/${order.orderId}`, { state: { order: order } });
    }
    useEffect(() => {
        fetchOrders(0)
    }, [])
    return (
        <Grid container spacing={2}  justifyContent="center"> 
         <Snackbar
                message={snackSetting.snackMessage}
                open={snackSetting.snackOpen}
                autoHideDuration={5000}
                onClose={() => setSnackSetting({ snackOpen: false })}
                action={<CloseSnackbarButton text={"Close"} action={() => setSnackSetting({ snackOpen: false })} />} />
            
            <Grid item xs={12}>
                <OrderStatusFilterItems selectStatus={selectStatus} onChange={changeOrderFilter}/>
            </Grid>
            {orders.map((order) => (
                <Grid item xs={12} sm={5} sx={{ m: 3 }} key={order.orderId}>
                    <Paper sx={{ p: 2, display: "flex", justifyContent: "space-between" }}>
                        <div>
                            <div>Delivery Address: {order.streetToDelivery}</div>
                            <div>
                                <FinalCostOrder finalCost={order.finalCost} promocode={order.promocode}/>
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
