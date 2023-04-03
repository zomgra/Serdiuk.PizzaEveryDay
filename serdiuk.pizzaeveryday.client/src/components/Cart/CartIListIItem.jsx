import { ListItem, Typography, IconButton } from "@mui/material";
import {Close} from '@mui/icons-material'
export default function CartIListItem({name, cost, id, removeFromOrder}) {
  return (
    <ListItem>
        <Typography
            variant="body1"
        >
            {name} {cost}$
        </Typography>
        <IconButton
            onClick={() => removeFromOrder(id)}
        >
            <Close />
        </IconButton>
    </ListItem>
);
}
