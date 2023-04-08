import React from 'react'
import ProductOrderItem from './ProductOrderItem'

export default function ProductOrderList({ products }) {
  return (
    // <Box component="ul" sx={{ listStyle: "none", p: 0, m: 0 }}>
   <>
      {products.map((product) => (
        <ProductOrderItem key={product.productId} product={product}/>
        ))}
   </>
    // </Box>
  )
}
