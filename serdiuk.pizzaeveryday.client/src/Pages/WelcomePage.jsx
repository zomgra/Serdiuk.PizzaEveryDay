import React from 'react'
import { Container, ImageList, ImageListItem, Select, MenuItem, Grid, FormControl, InputLabel, Button, Typography } from '@mui/material'
import { ALL_PIZZERIA_ADDRESSES } from '../utils/constance'

export default function WelcomePage() {
  return (
    <>
      <Container
        sx={{
          width: '100%',
          mt: '1rem',
        }}>
        <Grid container direction="row" spacing={4} xs={{ margin: 100 }}>
          <Grid item xs={7} columnGap={1}>
            <ImageList>
              <ImageListItem>
                <img src='https://images.unsplash.com/photo-1558642452-9d2a7deb7f62?w=242&h=242&fit=crop&auto=format' />
              </ImageListItem>
            </ImageList>
          </Grid>
          <Grid item xs={12 - 7} columnGap={1} rowGap={1}>
            <Typography
              component='h2'
              variant='h4'>
                Order in Pizza every day
                </Typography>
            <FormControl sx={{ m: 1, width: 300 }}>
              <InputLabel id="address-label">Address</InputLabel>
              <Select multiline
                labelId="Address pizzeria"
                id="demo-simple-select"
                label="Address pizzeria"
                variant='filled'
                autoWidth
              >
                {ALL_PIZZERIA_ADDRESSES.map((ad, id) => <MenuItem key={id}>{ad}</MenuItem>)}
              </Select>
            </FormControl>
          </Grid>
          <Grid xs={7}>

          </Grid>
          <Grid columnGap={2} xs={5}>
            <Button onClick={()=>{window.location.href='/restaurant'}} variant={'contained'} sx={{ml:10, mt:10}}>Confirm the address</Button>
          </Grid>
        </Grid>
      </Container>
    </>
  )
}
