
import { Route, Routes } from 'react-router-dom';
import './App.css';
import PrivateRouter from './utils/Router/PrivateRouter';
import WelcomePage from './Pages/WelcomePage';
import LoginPage from './Pages/LoginPage';
import LoginCallbackPage from './Callback/LoginCallbackPage'
import RestaurantPage from './Pages/RestaurantPage/RestaurantPage';
import { useState } from 'react';
import Header from './components/Header';

function App() {

  const [cartProduct, setCartProduct] = useState([]);
  const [isCartOpen, setCartOpen] = useState(false);

  function removeFromOrder(id) {
    setCartProduct(cartProduct.filter(product => product.id !== id));

  };


  return (
    <>
      <Header handleCart={() => setCartOpen(p => !p)} cartProduct={cartProduct} />
      <Routes>
        <Route path='/' element={<PrivateRouter />}>
          <Route path='/' element={<WelcomePage />}></Route>
          <Route path='/restaurant' element={<RestaurantPage cartProducts={cartProduct} isCartOpen={isCartOpen} setCartOpen={setCartOpen} setCartProduct={setCartProduct} removeFromOrder={removeFromOrder}/>}></Route>
        </Route>
        <Route path='/login' element={<LoginPage />}></Route>
        <Route path='/signin-oidc' element={<LoginCallbackPage />}></Route>
      </Routes>
    </>
  );
}

export default App;
