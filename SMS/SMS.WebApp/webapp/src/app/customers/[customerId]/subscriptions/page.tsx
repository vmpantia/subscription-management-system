'use client'
import { getCustomerBillingSubscriptions, getCustomerName, getCustomerSubscriptions } from '@/api/CustomerApis'
import CustomBreadcrumbs from '@/components/CustomBreadcrumbs'
import CustomCardCounts from '@/components/CustomCardCounts'
import CustomTable from '@/components/tables/common/CustomTable'
import { CustomerBillingSubscriptionsTableColumn, CustomerSubscriptionsTableColumn } from '@/components/tables/common/CustomTableColumns'
import { Result } from '@/interfaces/common/Result'
import { CustomBreadcrumbsPage } from '@/interfaces/props/CustomBreadcrumbsProps'
import { CustomCardCount } from '@/interfaces/props/CustomCardCountProps'
import { SubscriptionViewModel } from '@/interfaces/viewmodels/subscription/SubscriptionViewModel'
import React, { useEffect, useState } from 'react'

const page = ({ params }: { params: { customerId: string } }) => {

  // Hooks
  const [customerName, setCustomerName] = useState<string>('-');
  const [subscriptions, setSubscriptions] = useState<SubscriptionViewModel[]>([]);
  const [isSubscriptionsLoading, setIsSubscriptionsLoading] = useState<boolean>(true);
  const [billingSubscriptions, setBillingSubscriptions] = useState<SubscriptionViewModel[]>([]);
  const [isBillingSubscriptionsLoading, setIsBillingSubscriptionsLoading] = useState<boolean>(true);

  // Component Configurations
  const breadCrumbsConfig : CustomBreadcrumbsPage[] = [
    { link: 'http://localhost:3000/', name: 'Home' },
    { link: 'http://localhost:3000/customers', name: 'Customers' },
    { link: `http://localhost:3000/customers/${params.customerId}`, name: customerName },
    { link: null, name: 'Subscriptions' },
  ] 
  const cardsConfig : CustomCardCount[] = [
    { title: 'No. of Subscriptions', count: isSubscriptionsLoading ? '-' : subscriptions.length },
    { title: 'No. of Active Status', count: isSubscriptionsLoading ? '-' : subscriptions.filter(sub => sub.status === 'Active').length },
    { title: 'No. of Inactive Status', count: isSubscriptionsLoading ? '-' : subscriptions.filter(sub => sub.status === 'Inactive').length },
    { title: 'No. of Expired Status', count: isSubscriptionsLoading ? '-' : subscriptions.filter(sub => sub.status === 'Expired').length },
    { title: 'No. of Cancelled Status', count: isSubscriptionsLoading ? '-' : subscriptions.filter(sub => sub.status === 'Cancelled').length },
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
    setIsSubscriptionsLoading(true);
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
        setIsSubscriptionsLoading(false);
      });
  }
  const fetchCustomerBillingSubscriptions = () => {
    setIsBillingSubscriptionsLoading(true);
    getCustomerBillingSubscriptions(params.customerId)
      .then((res:Result<SubscriptionViewModel[]>) => {
        if(res.isSuccess)
          setBillingSubscriptions(res.data!);
        else
          console.log(`${res.error!.code} | ${res.error!.type} | ${res.error!.description}`);
      })
      .catch((err:any) => {
        console.log(err);
      })
      .finally(() => {
        setIsBillingSubscriptionsLoading(false);
      });
  }
  
  useEffect(() => {
    fetchCustomerName();
    fetchCustomerSubscriptions();
    fetchCustomerBillingSubscriptions();
  }, [])

  return (
    <>
      <CustomBreadcrumbs pages={breadCrumbsConfig} />
      <CustomCardCounts cards={cardsConfig} isLoading={isSubscriptionsLoading} />
      <CustomTable name='Subscriptions'
                  data={subscriptions}
                  columns={CustomerSubscriptionsTableColumn}
                  isLoading={isSubscriptionsLoading}
                  enableRowSelection={true}/>
      <CustomTable name='Billing Subscriptions'
                  data={billingSubscriptions}
                  columns={CustomerBillingSubscriptionsTableColumn}
                  isLoading={isBillingSubscriptionsLoading}
                  enableRowSelection={false}/>
    </>
  )
}

export default page