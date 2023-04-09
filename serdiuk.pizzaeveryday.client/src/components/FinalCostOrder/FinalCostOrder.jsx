import { Typography } from '@mui/material';
import React from 'react'

export default function FinalCostOrder({ finalCost, promocode }) {

    const realCost = promocode ? finalCost + promocode.discountAmount : finalCost;

    return (
        <>
            {promocode ? (
                <>
                    <Typography color="error" sx={{ whiteSpace: 'nowrap' }}>
                        Total cost:&nbsp;
                        <Typography
                            component="span"
                            variant="body2"
                            sx={{
                                textDecoration: 'line-through',
                                display: 'inline-block',
                                mr: 1,
                            }}
                        >
                            {realCost}
                        </Typography>
                        <Typography component="span" color={'textSecondary'} variant='body2' sx={{pb:1}}>{finalCost}</Typography>
                    </Typography>
                </>
            ) : (
                <Typography variant="body2" color="textSecondary">
                    Total cost: ${realCost}
                </Typography>
            )}
        </>
    )
}
