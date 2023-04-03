import { Card, CardMedia, CardContent, Typography, Grid, Button } from '@mui/material';
import React from 'react'
import { useState } from 'react';

export default function DrinkListItem({ drink, addInCart }) {
  return (
    <Grid item xs={12} sm={6} md={4}>
      <Card sx={{ display: 'flex', width: 370, maxHeight: 200, }}>
        <CardMedia
          component="img"
          sx={{ width: 200, objectFit: 'cover', maxHeight: '100%', maxWidth: '100%' }}
          image={drink.imageUrl}
          alt={drink.name}
        />
        <CardContent sx={{ display: 'flex', flexDirection: 'column' }}>
          <Typography variant="h5" component="h2" sx={{ flexGrow: 1 }}>
            {drink.name} - {drink.amount}L
          </Typography>
          <Typography variant="body2" color="text.secondary" sx={{ mb: 2 }}>
            {drink.cost} $.
          </Typography>
          <Button onClick={()=>{addInCart(drink.id,drink.name, drink.cost)}} variant="contained">Add in Cart</Button>
        </CardContent>
      </Card>
    </Grid>
  )
}
