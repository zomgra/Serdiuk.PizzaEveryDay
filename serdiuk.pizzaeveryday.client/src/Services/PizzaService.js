import axios from 'axios'
import { DEFAULT_API_URL } from '../utils/constance';
import { userManager } from './AuthService';

const instance = axios.create({
    baseURL: DEFAULT_API_URL,
});

async function getToken() {
    const user = await userManager.getUser();
    const token = `Bearer ${user.access_token}`
    return token;
}

export async function getAllProducts() {
    var response = await instance.get('/product');
    return response.data;
}
export async function getDiscountAmount(code) {
    var response = await instance.get('/promocode', {
        params: { code: code },
        headers: {
            'Authorization': await getToken(),
        }
    })
    return response;
}
export async function createOrderHandler(data) {
    console.log(await getToken());
    var response = await instance.post('/product/orders', JSON.stringify(data), {
        headers: {
            'Authorization': await getToken(),
            'Content-Type': 'application/json',
        }
    })
    return response;
}
export async function editOrder(data) {

    var response = await instance.put('/product/orders/edit', JSON.stringify(data), {

        headers: {
            'Authorization': await getToken(),
            'Content-Type': 'application/json',
        }
    })
    return response;
}
export async function cancelOrder(data) {
    var response = await instance.delete('/product/orders', {
        data: data,
        headers: {
            'Authorization': await getToken(),
        }
    })
    return response;
}
export async function payOrder(data) {
    var response = await instance.put('/product/orders', JSON.stringify(data), {
        headers: {
            'Authorization': await getToken(),
            'Content-Type': 'application/json',
        }
    })
    return response;
}
export async function getAllOrders(filter) {
    var response = await instance.get('product/orders', {
        headers: {
            'Authorization': await getToken(),
            'Content-Type': 'application/json',
        },
        params: {status: filter},
    })
    return response;
}