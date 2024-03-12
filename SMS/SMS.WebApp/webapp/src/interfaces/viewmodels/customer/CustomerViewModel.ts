export interface CustomerViewModel {
    id:string,
    name:string,
    currency:string,
    email:string,
    telephone:string,
    address:string,
    primaryContactName:string,
    primaryContactEmail:string,
    primaryContactTelephone:string,
    status:string,
    createdAt:string | Date,
    createdBy:string,
    updatedAt?:string | Date | null,
    updatedBy:string,

    billToCustomerId?:string | null,
    billToCustomerName?:string | null,
    billToCustomerCurrency?:string | null,

    noOfSubscriptions:number
}