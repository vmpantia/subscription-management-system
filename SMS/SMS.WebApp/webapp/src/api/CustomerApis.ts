import { AxiosApi } from "./AxiosApi";
import { Result } from "@/interfaces/common/Result";
import { CustomerSubscriptionViewModel } from "@/interfaces/viewmodels/customer/CustomerSubscriptionViewModel";
import { CustomerViewModel } from "@/interfaces/viewmodels/customer/CustomerViewModel";

export const getAllCustomers = () => 
    AxiosApi.get<Result<CustomerViewModel[]>>('customers')
            .then(({data}) => data);

export const getCustomerSubscriptionsById = (customerId:string) => 
    AxiosApi.get<Result<CustomerSubscriptionViewModel[]>>(`customers/${customerId}/subscriptions`)
            .then(({data}) => data);

export const getCustomerBillingSubscriptionsById = (customerId:string) => 
    AxiosApi.get<Result<CustomerSubscriptionViewModel[]>>(`customers/${customerId}/billing-subscriptions`)
            .then(({data}) => data);

export const getCustomerById = (customerId:string) => 
    AxiosApi.get<Result<CustomerViewModel>>(`customers/${customerId}`)
            .then(({data}) => data);