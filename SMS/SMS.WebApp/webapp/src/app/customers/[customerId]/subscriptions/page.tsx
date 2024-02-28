'use client'
import { getSubscriptions } from '@/api/SubscriptionApis'
import CustomBreadcrumbs from '@/components/CustomBreadcrumbs'
import CustomTable from '@/components/tables/common/CustomTable'
import { CustomerSubscriptionsTableColumn } from '@/components/tables/common/CustomTableColumns'
import { Result } from '@/interfaces/common/Result'
import { BreadcrumbsPage } from '@/interfaces/props/BreadcrumbsProps'
import { SubscriptionViewModel } from '@/interfaces/viewmodels/subscription/SubscriptionViewModel'
import React, { useEffect, useState } from 'react'

const page = ({ params }: { params: { customerId: string } }) => {

  const breadCrumbsConfig : BreadcrumbsPage[] = [
    { link: 'http://localhost:3000/', name: 'Home' },
    { link: 'http://localhost:3000/customers', name: 'Customer' },
    { link: `http://localhost:3000/customers/${params.customerId}`, name: params.customerId },
    { link: null, name: 'Subscriptions' },
  ] 

  const [subscriptions, setSubscriptions] = useState<SubscriptionViewModel[]>([]);
  const [isLoading, setIsLoading] = useState<boolean>(true);

  const fetchSubscriptions = () => {
    setIsLoading(true);
    getSubscriptions()
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

      <div className='py-5 text-xl font-bold text-slate-700'>
          <label>Subscriptions</label>
      </div>

      <CustomTable data={subscriptions}
                   columns={CustomerSubscriptionsTableColumn}
                   isLoading={isLoading}
                   enableRowSelection={true}/>
    </div>
  )
}

export default page