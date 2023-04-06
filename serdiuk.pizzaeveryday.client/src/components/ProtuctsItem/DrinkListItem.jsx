import React from 'react'
import {  Paper, ButtonBase, Typography, Grid, Button } from '@mui/material';
import styled from '@emotion/styled';

const Img = styled('img')({
  margin: 'auto',
  display: 'block',
  maxWidth: '100%',
  maxHeight: '100%',
});


export default function DrinkListItem({ drink, addInCart }) {
  return (
    <Grid item xs={12} sm={6} md={6}>
      <Paper
        sx={{
          p: 2,
          margin: 'auto',
          maxWidth: 500,
          width: 400,
          height: 150,
          flexGrow: 1,
          backgroundColor: (theme) =>
            theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
        }}
      >
        <Grid container spacing={2}>
          <Grid item>
            <ButtonBase sx={{ width: 128, height: 128 }}>
              <Img alt="pizza" src={drink.imageUrl} />
            </ButtonBase>
          </Grid>
          <Grid item xs={12} sm container>
            <Grid item xs container direction="column" spacing={2}>
              <Grid item xs>
                <Typography gutterBottom variant="subtitle1" component="div">
                  {drink.name} - {drink.amount}L
                </Typography>
                {/* <Typography variant="body2" gutterBottom>
                  {ingredients}
                </Typography> */}
                <Typography variant="body2" color="text.secondary">
                {drink.amount} liter
              </Typography>
              </Grid>
              <Grid item>
                <Button
                  onClick={() => { addInCart(drink.id, drink.name, drink.cost) }}
                  variant={'contained'} sx={{ cursor: 'pointer' }} >
                  Add In Cart
                </Button>
              </Grid>
            </Grid>
            <Grid item>
              <Typography variant="subtitle1" component="div">
                ${drink.cost}
              </Typography>
            </Grid>
          </Grid>
        </Grid>
      </Paper>
    </Grid>
  )
}
