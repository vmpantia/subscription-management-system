import CustomBreadcrumbs from '@/components/CustomBreadcrumbs'
import { CustomBreadcrumbsPage } from '@/interfaces/props/CustomBreadcrumbsProps'
import React from 'react'

const page = () => {
    // Component Configurations
    const breadCrumbsConfig : CustomBreadcrumbsPage[] = [
        { link: 'http://localhost:3000/', name: 'Home' },
        { link: null, name: 'Customers' },
    ] 
    
    return (
        <>
            <CustomBreadcrumbs pages={breadCrumbsConfig} />
        </>
    )
}

export default page