export const DEFAULT_API_URL = "https://localhost:7001/api/"
const CURRENT_URL = "http://localhost:3000"

export const AUTH_CONFIG = {
    authority: 'https://localhost:10001/',
    client_id: 'pizza-api',
    redirect_uri: `${CURRENT_URL}/signin-oidc`,
    post_logout_redirect_uri: `${CURRENT_URL}/login`,
    response_type: 'id_token token',
    scope: 'openid profile PizzaApi offline_access',
    accessTokenExpiringNotificationTime: 300,
    automaticSilentRenew: true,
    silent_redirect_uri: `${CURRENT_URL}/silent-renew`,
    persistAccessToken: true,
}
export const ALL_PIZZERIA_ADDRESSES = [
    "Frankfurt Am Main Hesse 9",
    "Leipziger Platz 12	Berlin",
    "Muenzstrasse 13 Braunschweig",
]