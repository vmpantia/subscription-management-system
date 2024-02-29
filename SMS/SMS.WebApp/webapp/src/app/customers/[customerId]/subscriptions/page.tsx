'use client'
import { getCustomerName, getCustomerSubscriptions } from '@/api/CustomerApis'
import CustomBreadcrumbs from '@/components/CustomBreadcrumbs'
import CustomCardCounts from '@/components/CustomCardCounts'
import CustomTable from '@/components/tables/common/CustomTable'
import { CustomerSubscriptionsTableColumn } from '@/components/tables/common/CustomTableColumns'
import { Result } from '@/interfaces/common/Result'
import { CustomBreadcrumbsPage } from '@/interfaces/props/CustomBreadcrumbsProps'
import { CustomCardCount } from '@/interfaces/props/CustomCardCountProps'
import { SubscriptionViewModel } from '@/interfaces/viewmodels/subscription/SubscriptionViewModel'
import { EditOutlined, SettingsOutlined } from '@mui/icons-material'
import { Avatar, Card, Skeleton } from 'antd'
import Meta from 'antd/es/card/Meta'
import React, { useEffect, useState } from 'react'

const page = ({ params }: { params: { customerId: string } }) => {

  // Hooks
  const [subscriptions, setSubscriptions] = useState<SubscriptionViewModel[]>([]);
  const [isLoading, setIsLoading] = useState<boolean>(true);
  const [customerName, setCustomerName] = useState<string>('-');

  // Component Configurations
  const breadCrumbsConfig : CustomBreadcrumbsPage[] = [
    { link: 'http://localhost:3000/', name: 'Home' },
    { link: 'http://localhost:3000/customers', name: 'Customer' },
    { link: `http://localhost:3000/customers/${params.customerId}`, name: customerName },
    { link: null, name: 'Subscriptions' },
  ] 
  const cardsConfig : CustomCardCount[] = [
    { title: 'No. of Subscriptions', count: isLoading ? '-' : subscriptions.length },
    { title: 'No. of Active Status', count: isLoading ? '-' : subscriptions.filter(sub => sub.status === 'Active').length },
    { title: 'No. of Inactive Status', count: isLoading ? '-' : subscriptions.filter(sub => sub.status === 'Inactive').length },
    { title: 'No. of Expired Status', count: isLoading ? '-' : subscriptions.filter(sub => sub.status === 'Expired').length },
    { title: 'No. of Cancelled Status', count: isLoading ? '-' : subscriptions.filter(sub => sub.status === 'Cancelled').length },
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
  const fetchCustomerSubscriptions = () => {
    setIsLoading(true);
    getCustomerSubscriptions(params.customerId)
      .then((res:Result<SubscriptionViewModel[]>) => {
        if(res.isSuccess)
          setSubscriptions(res.data!);
        else
          console.log(`${res.error!.code} | ${res.error!.type} | ${res.error!.description}`);
      })
      .catch((err:any) => {
        console.log(err);
      })
      .finally(() => {
        setIsLoading(false);
      });
  }
  
  useEffect(() => {
    fetchCustomerSubscriptions();
    fetchCustomerName();
  }, [])

  return (
    <div className='p-10'>
      <CustomBreadcrumbs pages={breadCrumbsConfig} />
      <CustomCardCounts cards={cardsConfig} isLoading={isLoading} />
      <CustomTable name='Subscriptions'
                   data={subscriptions}
                   columns={CustomerSubscriptionsTableColumn}
                   isLoading={isLoading}
                   enableRowSelection={true}/>
    </div>
  )
}

export default page