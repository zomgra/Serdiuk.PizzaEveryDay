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
    console.log(responce);
    return responce.data;

}