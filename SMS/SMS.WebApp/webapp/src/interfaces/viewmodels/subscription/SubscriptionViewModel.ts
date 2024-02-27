interface SubscriptionViewModel {
    id:string,
    name:string,
    description?:string | null,
    quantity:number,
    unitPrice:number,
    annivesaryDate:Date,
    servicePeriodStartAt:Date,
    servicePeriodEndAt:Date,
    activationDate:Date,
    isAutomaticRenewal:boolean,
    paymentCycle:string,
    subscriptionCycle:string,
    status:string,
    createdAt:Date,
    createdBy:string,
    updatedAt?:Date | null,
    updatedBy?:string | null,

    productId:string,
    productName:string,
    productVendor:string,
    productManufacturer:string,
    productGroupName:string,
    productTypeName:string
}