export interface AddressDto {
    id:string;
    employeeId:string;
    address:string;
    line1:string;
    line2?:string;
    barangay:string;
    city:string;
    province:string;
    zipCode:string;
    country:string;
    type:string;
    status:string;
}