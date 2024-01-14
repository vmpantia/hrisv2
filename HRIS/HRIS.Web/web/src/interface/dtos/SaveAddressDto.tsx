interface SaveAddressDto {
    Id?:string;
    Line1:string;
    Line2?:string;
    Barangay:string;
    City:string;
    Province:string;
    ZipCode:string;
    Country:string;
    Type:AddressType;
}