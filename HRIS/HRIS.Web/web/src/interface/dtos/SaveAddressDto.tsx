interface SaveAddressDto {
    id?:string;
    line1:string;
    line2?:string;
    barangay:string;
    city:string;
    province:string;
    zipCode:string;
    country:string;
    type:AddressType;
}