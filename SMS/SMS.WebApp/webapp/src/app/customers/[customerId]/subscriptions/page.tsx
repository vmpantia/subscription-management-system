'use client'
import { getSubscriptions } from '@/api/SubscriptionApis'
import CustomerSubscriptionsTable from '@/components/tables/CustomerSubscriptionsTable'
import { Result } from '@/interfaces/common/Result'
import { SubscriptionViewModel } from '@/interfaces/viewmodels/subscription/SubscriptionViewModel'
import React, { useEffect, useState } from 'react'

const page = ({ params }: { params: { customerId: string } }) => {
  const [subscriptions, setSubscriptions] = useState<SubscriptionViewModel[]>([]);
  const [isLoading, setIsLoading] = useState<boolean>(true);

  useEffect(() => {
    const fetchSubscriptions = () => {
      setIsLoading(true);
      getSubscriptions()
        .then((res:Result<SubscriptionViewModel[]>) => {
          console.log(res);
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
    fetchSubscriptions();
  }, [])

  return (
      <CustomerSubscriptionsTable 
            data={subscriptions}
            isLoading={isLoading} />
  )
}

export default page