'use client'
import { getCustomerName } from '@/api/CustomerApis';
import CustomBreadcrumbs from '@/components/CustomBreadcrumbs';
import { Result } from '@/interfaces/common/Result';
import { CustomBreadcrumbsPage } from '@/interfaces/props/CustomBreadcrumbsProps';
import React, { useEffect, useState } from 'react'

const page = ({ params }: { params: { customerId: string } }) => {
    
    // Hooks
    const [customerName, setCustomerName] = useState<string>('-');
    
    // Component Configurations
    const breadCrumbsConfig : CustomBreadcrumbsPage[] = [
        { link: 'http://localhost:3000/', name: 'Home' },
        { link: 'http://localhost:3000/customers', name: 'Customer' },
        { link: null, name: customerName },
    ] 
    
    // Functions
    const fetchCustomerName = () => {
        getCustomerName(params.customerId)
        .then((res:Result<string>) => {
            if(res.isSuccess)
            setCustomerName(res.data!);
            else
            console.log(`${res.error!.code} | ${res.error!.type} | ${res.error!.description}`);
        })
        .catch((err:any) => {
            console.log(err);
        });
    }

    useEffect(() => {
        fetchCustomerName();
    }, [])
    
    return (
        <>
            <CustomBreadcrumbs pages={breadCrumbsConfig} />
        </>
    )
}

export default page