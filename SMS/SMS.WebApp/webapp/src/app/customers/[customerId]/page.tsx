'use client'
import { getCustomerById } from '@/api/CustomerApis';
import CustomBreadcrumbs from '@/components/CustomBreadcrumbs';
import { Result } from '@/interfaces/common/Result';
import { CustomBreadcrumbsPage } from '@/interfaces/props/CustomBreadcrumbsProps';
import { CustomerViewModel } from '@/interfaces/viewmodels/customer/CustomerViewModel';
import React, { useEffect, useState } from 'react'

const page = ({ params }: { params: { customerId: string } }) => {
    
    // Hooks
    const [customerName, setCustomerName] = useState<string>('-');
    
    // Component Configurations
    const breadCrumbsConfig : CustomBreadcrumbsPage[] = [
        { link: 'http://localhost:3000/', name: 'Home' },
        { link: 'http://localhost:3000/customers', name: 'Customers' },
        { link: null, name: customerName },
    ] 
    
    // Functions
    const fetchCustomerById = () => {
        getCustomerById(params.customerId)
        .then((res:Result<CustomerViewModel>) => {
            if(res.isSuccess)
                setCustomerName(res.data!.name);
            else
                console.log(`${res.error!.code} | ${res.error!.type} | ${res.error!.description}`);
        })
        .catch((err:any) => {
            console.log(err);
        });
    }

    useEffect(() => {
        fetchCustomerById();
    }, [])
    
    return (
        <>
            <CustomBreadcrumbs pages={breadCrumbsConfig} />
        </>
    )
}

export default page