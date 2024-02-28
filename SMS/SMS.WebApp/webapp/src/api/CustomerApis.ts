import { SubscriptionViewModel } from "@/interfaces/viewmodels/subscription/SubscriptionViewModel";
import { AxiosApi } from "./AxiosApi";
import { Result } from "@/interfaces/common/Result";

export const getCustomerSubscriptions = (customerId:string) => 
    AxiosApi.get<Result<SubscriptionViewModel[]>>(`customers/${customerId}/subscriptions`)
            .then(({data}) => data);

export const getCustomerName = (customerId:string) => 
    AxiosApi.get<Result<string>>(`customers/${customerId}/name`)
            .then(({data}) => data);