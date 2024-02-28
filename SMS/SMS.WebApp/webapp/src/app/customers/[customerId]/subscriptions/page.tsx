'use client'
import { getCustomerSubscriptions } from '@/api/CustomerApis'
import CustomBreadcrumbs from '@/components/CustomBreadcrumbs'
import CustomCardCounts from '@/components/CustomCardCounts'
import CustomTable from '@/components/tables/common/CustomTable'
import { CustomerSubscriptionsTableColumn } from '@/components/tables/common/CustomTableColumns'
import { Result } from '@/interfaces/common/Result'
import { CustomBreadcrumbsPage } from '@/interfaces/props/CustomBreadcrumbsProps'
import { CustomCardCount } from '@/interfaces/props/CustomCardCountProps'
import { SubscriptionViewModel } from '@/interfaces/viewmodels/subscription/SubscriptionViewModel'
import React, { useEffect, useState } from 'react'

const page = ({ params }: { params: { customerId: string } }) => {
  const breadCrumbsConfig : CustomBreadcrumbsPage[] = [
    { link: 'http://localhost:3000/', name: 'Home' },
    { link: 'http://localhost:3000/customers', name: 'Customer' },
    { link: `http://localhost:3000/customers/${params.customerId}`, name: params.customerId },
    { link: null, name: 'Subscriptions' },
  ] 
  const cardsConfig : CustomCardCount[] = [
    { title: 'No. of Active Status', count: 5 },
    { title: 'No. of Inactive Status', count: 5 },
    { title: 'No. of Deleted Status', count: 5 },
  ]

  const [subscriptions, setSubscriptions] = useState<SubscriptionViewModel[]>([]);
  const [isLoading, setIsLoading] = useState<boolean>(true);

  const fetchSubscriptions = () => {
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
    fetchSubscriptions();
  }, [])

  return (
    <div className='p-10'>
      <CustomBreadcrumbs pages={breadCrumbsConfig} />
      <CustomCardCounts cards={cardsConfig} />
      <CustomTable name='Subscriptions'
                   data={subscriptions}
                   columns={CustomerSubscriptionsTableColumn}
                   isLoading={isLoading}
                   enableRowSelection={true}/>
    </div>
  )
}

export default page