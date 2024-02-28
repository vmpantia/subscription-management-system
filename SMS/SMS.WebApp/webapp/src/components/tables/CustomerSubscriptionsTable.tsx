import React from 'react'
import { CustomerSubscriptionsTableColumn } from './common/CustomTableColumns';
import { CustomerSubscriptionsTableProps } from '@/interfaces/props/CustomerSubscriptionsTableProps';
import CustomTable from './common/CustomTable';

const CustomerSubscriptionsTable : React.FC<CustomerSubscriptionsTableProps> = ({ data, isLoading }) => {
    return (
        <div className='p-10'>
            <div className='py-5 text-xl font-bold'>
                <label>Subscriptions</label>
            </div>
            <CustomTable data={data}
                         columns={CustomerSubscriptionsTableColumn}
                         isLoading={isLoading}
                         enableRowSelection={true}/>
        </div>
    )
}

export default CustomerSubscriptionsTable