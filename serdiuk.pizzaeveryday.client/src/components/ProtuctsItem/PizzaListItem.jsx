import React from 'react'
import { Card, CardMedia, CardContent, Typography, Grid, CardActions, Button } from '@mui/material';



export default function PizzaListItem({id, name, cost, imageUrl, ingredients, addInCart }) {
  return (
    <Grid item xs={12} sm={6} md={4}>
      {console.log(id)}
      <Card sx={{ display: 'flex', width:370 ,alignItems: 'center', maxHeight: 230}}>
        <Grid container>
          <Grid item xs={4}>
            <CardMedia
              component="img"
              height="200"
              width='200'
              image={imageUrl}
              alt={name}
            />
          </Grid>
          <Grid item xs={8}>
            <CardContent sx={{ objectFit: 'cover' }}>
              <Typography variant="h5" component="h2">
                {name}
              </Typography>
              <Typography color="textSecondary">
                {ingredients}
              </Typography>
              <Typography variant="h6" sx={{ml:6}} component="p">
                {cost} $
              </Typography>
            </CardContent>
            <CardActions>
              <Button onClick={()=>{addInCart(id,name,cost)}} sx={{ml:4}} variant={'contained'} size='small' color='primary'>Add In Cart</Button>
            </CardActions>
          </Grid>
        </Grid>
      </Card>
    </Grid>
  );
}


