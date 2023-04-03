import {UserManager} from 'oidc-client'
import { AUTH_CONFIG } from '../utils/constance'

export const userManager = new UserManager(AUTH_CONFIG);
