'use client'
import { getAllCustomers } from '@/api/CustomerApis';
import CustomBreadcrumbs from '@/components/CustomBreadcrumbs'
import CustomCardCounts from '@/components/CustomCardCounts';
import CustomTable from '@/components/tables/common/CustomTable';
import { CustomerTableColumn } from '@/components/tables/common/CustomTableColumns';
import { Result } from '@/interfaces/common/Result';
import { CustomBreadcrumbsPage } from '@/interfaces/props/CustomBreadcrumbsProps'
import { CustomCardCount } from '@/interfaces/props/CustomCardCountProps';
import { CustomerViewModel } from '@/interfaces/viewmodels/customer/CustomerViewModel';
import React, { useEffect, useState } from 'react'

const page = () => {

    // Hooks
    const [customers, setCustomers] = useState<CustomerViewModel[]>([]);
    const [isCustomerLoading, setIsCustomerLoading] = useState<boolean>(true);

    // Component Configurations
    const breadCrumbsConfig : CustomBreadcrumbsPage[] = [
        { link: 'http://localhost:3000/', name: 'Home' },
        { link: null, name: 'Customers' },
    ] 
    const cardsConfig : CustomCardCount[] = [
        { title: 'No. of Customers', count: isCustomerLoading ? '-' : customers.length },
        { title: 'No. of Active Status', count: isCustomerLoading ? '-' : customers.filter(sub => sub.status === 'Active').length },
        { title: 'No. of Inactive Status', count: isCustomerLoading ? '-' : customers.filter(sub => sub.status === 'Inactive').length },
    ]
    
    // Functions
    const fetchCustomers = () => {
        setIsCustomerLoading(true);
        getAllCustomers()
        .then((res:Result<CustomerViewModel[]>) => {
            if(res.isSuccess)
                setCustomers(res.data!);
            else
                console.log(`${res.error!.code} | ${res.error!.type} | ${res.error!.description}`);
        })
        .catch((err:any) => {
            console.log(err);
        })
        .finally(() => {
            setIsCustomerLoading(false);
        });
    }
    
    useEffect(() => {
        fetchCustomers();
    }, [])

    return (
        <>
            <CustomBreadcrumbs pages={breadCrumbsConfig} />
            <CustomCardCounts cards={cardsConfig} isLoading={isCustomerLoading} />
            <CustomTable name='Customers'
                        data={customers}
                        columns={CustomerTableColumn}
                        isLoading={isCustomerLoading}
                        enableRowSelection={false}/>
        </>
    )
}

export default page