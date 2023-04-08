import React from 'react'
import { ORDER_STATUS_COLORS, ORDER_STATUS_LOOKUP } from '../../utils/constance'
import { Chip, Typography } from '@mui/material';
import { makeStyles } from '@mui/styles'

export default function OrderStatusText({ statusId }) {
    const status = ORDER_STATUS_LOOKUP[statusId];
    const color = ORDER_STATUS_COLORS[statusId];

    const useStyles = makeStyles((theme) => ({
        chip: {
            backgroundColor: color,
            color:'wheat'
        }
    }))

    const classes = useStyles();
    return (
        <>
            <Typography sx={{
                mr:1,
                fontWeight: '600',
                fontSize: '14px',
                lineHeight: '20px',
            }}>
                Status:
            </Typography>
            <Chip
                label={status}
                className={classes.chip}
            />
        </>
    )
}
