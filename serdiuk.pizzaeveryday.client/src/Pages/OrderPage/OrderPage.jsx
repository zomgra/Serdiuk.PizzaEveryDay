import React from 'react'
import { Box, Button, Divider, IconButton, InputAdornment, LinearProgress, Snackbar, TextField } from "@mui/material";
import EditIcon from "@mui/icons-material/Edit";
import { useLocation } from 'react-router-dom'
import { useState } from 'react';
import { cancelOrder, editOrder, payOrder } from '../../Services/PizzaService';
import { useEffect } from 'react';
import CloseSnackbarButton from '../../components/CloseSnackbarButton/CloseSnackbarButton';
import ProductOrderList from '../../components/ProductOrderList/ProductOrderList';
import TotalCostText from '../../components/TotalCostText/TotalCostText';
import OrderStatusText from '../../components/OrderStatusText/OrderStatusText';
import IntegrationButtons from '../../components/IntegrationButtons/IntegrationButtons';

export default function OrderPage() {

    const [isEditStreet, setEditStreet] = useState(false);
    const [editedStreet, setEditedStreet] = useState();
    const [snackSetting, setSnackSetting] = useState({ snackOpen: false, snackMessage: '' })
    const [order, setOrder] = useState()

    const location = useLocation();
    useEffect(() => {

        setEditedStreet(location.state.order.streetToDelivery)
        setOrder(location.state.order);
    }, [])

    async function payHandler() {
        var data = {orderId: order.orderId};

        try{
            var responce = await payOrder(data);
            setOrder(responce.data);
            snackHandler('success pay order');
        }
        catch(e){
            snackHandler(e.response.data)
        }
    }

    async function cancelHandler() {
        var data = {orderId: order.orderId};
        try{
            var responce = await cancelOrder(data);
            setOrder(responce.data);
            snackHandler('success cancel order');
        }
        catch(e){
            
            snackHandler(e.response.data)
        }
    }
    function handleEdit() {
        setEditStreet(e => !e);
        console.log(isEditStreet);
    }
    async function submitEditStreet() {

        const data = { orderId: order.orderId, street: editedStreet }
        try {
            var responce = await editOrder(data);
            setOrder(responce.data);
            snackHandler('success edit street')
        }
        catch (e) {
            snackHandler(e.response.data)
        }
    }
    function snackHandler(message) {
        setSnackSetting({ snackOpen: true, snackMessage: message });
    }

    if (!order || !order.products)
        return (
            <LinearProgress />
        )
    return (
        <>
            <Snackbar
                message={snackSetting.snackMessage}
                open={snackSetting.snackOpen}
                autoHideDuration={5000}
                onClose={() => setSnackSetting({ snackOpen: false })}
                action={<CloseSnackbarButton text={"Close"} action={() => setSnackSetting({ snackOpen: false })} />} />
            <Box sx={{ p: 2 }}>
                <TextField
                    label="Street to Delivery"
                    value={editedStreet}
                    InputProps={{
                        endAdornment: (
                            <InputAdornment position="end">
                                <IconButton onClick={() => handleEdit()}>
                                    <EditIcon />
                                </IconButton>
                            </InputAdornment>
                        ),
                    }}
                    fullWidth
                    onChange={(e) => setEditedStreet(e.target.value)}
                    disabled={!isEditStreet}
                    sx={{ mb: 2 }}
                />
                {isEditStreet && (
                    <Button variant={'contained'} sx={{ m: '20px' }} onClick={() => submitEditStreet()}>
                        Submit
                    </Button>
                )}
                <TextField
                    label="Promocode"
                    value={order.promocode ?? "N/A"}
                    fullWidth
                    disabled
                    sx={{ mb: 2 }}
                />
                <OrderStatusText statusId={order.status}/>
                <Box component="ul" sx={{ listStyle: "none", p: 0, m: 0 }}>
                    <ProductOrderList products={order.products} />
                    <Divider sx={{ my: 2 }} variant={'middle'} />
                    <TotalCostText cost={order.finalCost} />
                </Box>

                <IntegrationButtons statusId={order.status} payHandler={payHandler} cancelHandler={cancelHandler}/>
            </Box>
        </>
    )
}
