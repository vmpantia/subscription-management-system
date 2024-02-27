'use client'

import CustomerSubscriptionsTable from '@/components/tables/CustomerSubscriptionsTable'
import { SubscriptionViewModel } from '@/interfaces/viewmodels/subscription/SubscriptionViewModel'
import React from 'react'

const page = ({ params }: { params: { customerId: string } }) => {

  const subscriptions = [
    { name: 'takte', productName: 'takteqweqweqweqweqweqweqwe', anniversaryDate: '2023-02-27',  servicePeriodStartAt: '2023-02-27', servicePeriodEndAt: '2023-02-27', activationDate: '2023-02-27', isAutomaticRenewal: true, paymentCycle: 'Yearly', subscriptionCycle: 'Monthly'},
    { name: 'takte', productName: 'takteqweqweqweqweqweqweqwe', anniversaryDate: '2023-02-27',  servicePeriodStartAt: '2023-02-27', servicePeriodEndAt: '2023-02-27', activationDate: '2023-02-27', isAutomaticRenewal: true, paymentCycle: 'Yearly', subscriptionCycle: 'Monthly'},
    { name: 'takte', productName: 'takteqweqweqweqweqweqweqwe', anniversaryDate: '2023-02-27',  servicePeriodStartAt: '2023-02-27', servicePeriodEndAt: '2023-02-27', activationDate: '2023-02-27', isAutomaticRenewal: true, paymentCycle: 'Yearly', subscriptionCycle: 'Monthly'},
    { name: 'takte', productName: 'takteqweqweqweqweqweqweqwe', anniversaryDate: '2023-02-27',  servicePeriodStartAt: '2023-02-27', servicePeriodEndAt: '2023-02-27', activationDate: '2023-02-27', isAutomaticRenewal: true, paymentCycle: 'Yearly', subscriptionCycle: 'Monthly'},
    { name: 'takte', productName: 'takte', anniversaryDate: '2023-02-27',  servicePeriodStartAt: '2023-02-27', servicePeriodEndAt: '2023-02-27', activationDate: '2023-02-27', isAutomaticRenewal: true, paymentCycle: 'Yearly', subscriptionCycle: 'Monthly'},
    { name: 'takte', productName: 'takte', anniversaryDate: '2023-02-27',  servicePeriodStartAt: '2023-02-27', servicePeriodEndAt: '2023-02-27', activationDate: '2023-02-27', isAutomaticRenewal: true, paymentCycle: 'Yearly', subscriptionCycle: 'Monthly'},
    { name: 'takte', productName: 'takte', anniversaryDate: '2023-02-27',  servicePeriodStartAt: '2023-02-27', servicePeriodEndAt: '2023-02-27', activationDate: '2023-02-27', isAutomaticRenewal: true, paymentCycle: 'Yearly', subscriptionCycle: 'Monthly'},
    { name: 'takte', productName: 'takte', anniversaryDate: '2023-02-27',  servicePeriodStartAt: '2023-02-27', servicePeriodEndAt: '2023-02-27', activationDate: '2023-02-27', isAutomaticRenewal: true, paymentCycle: 'Yearly', subscriptionCycle: 'Monthly'},
    { name: 'takte', productName: 'takte', anniversaryDate: '2023-02-27',  servicePeriodStartAt: '2023-02-27', servicePeriodEndAt: '2023-02-27', activationDate: '2023-02-27', isAutomaticRenewal: true, paymentCycle: 'Yearly', subscriptionCycle: 'Monthly'},
    { name: 'takte', productName: 'takte', anniversaryDate: '2023-02-27',  servicePeriodStartAt: '2023-02-27', servicePeriodEndAt: '2023-02-27', activationDate: '2023-02-27', isAutomaticRenewal: true, paymentCycle: 'Yearly', subscriptionCycle: 'Monthly'},
    { name: 'takte', productName: 'takte', anniversaryDate: '2023-02-27',  servicePeriodStartAt: '2023-02-27', servicePeriodEndAt: '2023-02-27', activationDate: '2023-02-27', isAutomaticRenewal: true, paymentCycle: 'Yearly', subscriptionCycle: 'Monthly'},
    { name: 'takte', productName: 'takte', anniversaryDate: '2023-02-27',  servicePeriodStartAt: '2023-02-27', servicePeriodEndAt: '2023-02-27', activationDate: '2023-02-27', isAutomaticRenewal: true, paymentCycle: 'Yearly', subscriptionCycle: 'Monthly'},
    { name: 'takte', productName: 'takte', anniversaryDate: '2023-02-27',  servicePeriodStartAt: '2023-02-27', servicePeriodEndAt: '2023-02-27', activationDate: '2023-02-27', isAutomaticRenewal: true, paymentCycle: 'Yearly', subscriptionCycle: 'Monthly'},
    { name: 'takte', productName: 'takte', anniversaryDate: '2023-02-27',  servicePeriodStartAt: '2023-02-27', servicePeriodEndAt: '2023-02-27', activationDate: '2023-02-27', isAutomaticRenewal: true, paymentCycle: 'Yearly', subscriptionCycle: 'Monthly'},
    { name: 'takte', productName: 'takte', anniversaryDate: '2023-02-27',  servicePeriodStartAt: '2023-02-27', servicePeriodEndAt: '2023-02-27', activationDate: '2023-02-27', isAutomaticRenewal: true, paymentCycle: 'Yearly', subscriptionCycle: 'Monthly'},
    { name: 'takte', productName: 'takte', anniversaryDate: '2023-02-27',  servicePeriodStartAt: '2023-02-27', servicePeriodEndAt: '2023-02-27', activationDate: '2023-02-27', isAutomaticRenewal: true, paymentCycle: 'Yearly', subscriptionCycle: 'Monthly'},
  ] as SubscriptionViewModel[]

  return (
      <CustomerSubscriptionsTable 
            data={subscriptions}
            isLoading={false} />
  )
}

export default page