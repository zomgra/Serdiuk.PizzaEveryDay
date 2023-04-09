import { MenuItem, Select } from '@mui/material'
import React from 'react'
import { ORDER_STATUS_LOOKUP } from '../../utils/constance'
import { useState } from 'react';

export default function OrderStatusFilterItems({ onChange, selectStatus }) {
    
    
    
    const menuItems = Object.entries(ORDER_STATUS_LOOKUP).map(([value, label]) => (
        <MenuItem key={value} value={value}>
            {label}
        </MenuItem>
    ));

    return (
        <Select value={selectStatus}
        label={'Filter by status'} onChange={(e) => onChange(e.target.value)}>
            {menuItems}
        </Select>
    );
}
