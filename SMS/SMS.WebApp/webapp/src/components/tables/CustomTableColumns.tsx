import { SubscriptionViewModel } from "@/interfaces/viewmodels/subscription/SubscriptionViewModel";
import { MRT_ColumnDef } from "material-react-table";

const defaultColumn = (header:string, key:string, colWidth:number = 100) => {
    return {
        id: key,
        header: header,
        size: colWidth,
        accessorKey: key
    }
}

export const CustomerSubscriptionsTableColumn : MRT_ColumnDef<SubscriptionViewModel>[] = [
    defaultColumn('Subscription', 'name') as MRT_ColumnDef<SubscriptionViewModel>,
    defaultColumn('Product', 'productName') as MRT_ColumnDef<SubscriptionViewModel>,
    defaultColumn('Anniversary Date', 'anniversaryDate') as MRT_ColumnDef<SubscriptionViewModel>,
    defaultColumn('Service Period Start At', 'servicePeriodStartAt') as MRT_ColumnDef<SubscriptionViewModel>,
    defaultColumn('Service Period End At', 'servicePeriodEndAt') as MRT_ColumnDef<SubscriptionViewModel>,
    defaultColumn('Activation Date', 'activationDate') as MRT_ColumnDef<SubscriptionViewModel>,
    defaultColumn('Is Auto Renewal?', 'isAutomaticRenewal') as MRT_ColumnDef<SubscriptionViewModel>,
    defaultColumn('Payment Cycle', 'paymentCycle') as MRT_ColumnDef<SubscriptionViewModel>,
    defaultColumn('Subscription Cycle', 'subscriptionCycle') as MRT_ColumnDef<SubscriptionViewModel>,
]