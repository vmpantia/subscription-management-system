import { MaterialReactTable } from 'material-react-table';
import React, { useState } from 'react'
import { CustomerSubscriptionsTableColumn } from './CustomTableColumns';
import { CustomerSubscriptionsTableProps } from '@/interfaces/props/CustomerSubscriptionsTableProps';

const CustomerSubscriptionsTable : React.FC<CustomerSubscriptionsTableProps> = ({ data }) => {
    const [subscriptions, setSubscriptions] = useState(data);

    return (
        <MaterialReactTable 
            data={subscriptions}
            columns={CustomerSubscriptionsTableColumn} />
    )
}

export default CustomerSubscriptionsTable