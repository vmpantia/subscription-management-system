import { SubscriptionViewModel } from "../subscription/SubscriptionViewModel";

export interface CustomerSubscriptionViewModel extends SubscriptionViewModel {
    customerId:string,
    customerName:string,
    customerCurrency:string,
    billToCustomerId:string,
    billToCustomerName:string,
    billToCustomerCurrency:string,
}