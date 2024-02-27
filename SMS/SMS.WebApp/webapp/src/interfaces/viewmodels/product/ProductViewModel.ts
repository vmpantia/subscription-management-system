export interface ProductViewModel {
    id:string,
    name:string,
    code:string,
    description?:string | null,
    vendor:string,
    vendorProductCode:string,
    vendorContractTerm:string,
    manufacturer:string,
    status:string,
    createdAt:string | Date,
    createdBy:string,
    updatedAt?:string | Date | null,
    updatedBy:string,

    productGroupId:string,
    productGroupName:string,
    productTypeName:string
}