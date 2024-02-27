'use client'

import CustomerSubscriptionsTable from '@/components/tables/CustomerSubscriptionsTable'
import { SubscriptionViewModel } from '@/interfaces/viewmodels/subscription/SubscriptionViewModel'
import React from 'react'

const page = ({ params }: { params: { customerId: string } }) => {
  return (
      <CustomerSubscriptionsTable data={[] as SubscriptionViewModel[]} />
  )
}

export default page