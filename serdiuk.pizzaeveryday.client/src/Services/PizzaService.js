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
    var responce = await instance.get('/product');
    return responce.data;
}
export async function getDiscountAmount(code) {
    var responce = await instance.get('/promocode',{
        params: {code:code},
        headers:{
            'Authorization': await getToken(),
        }
    })
    return responce;
}
export async function createOrderHandler(data){
    var responce = await instance.post('/product/orders',JSON.stringify(data),{
        headers:{
            'Authorization': await getToken(),
            'Content-Type': 'application/json',
        }
    })
    return responce;
}