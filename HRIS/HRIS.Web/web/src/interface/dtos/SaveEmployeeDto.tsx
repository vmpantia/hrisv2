interface SaveEmployeeDto {
    firstName:string;
    middleName?:string;
    lastName:string;
    gender:string;
    birthDate:Date;
    contacts:SaveContactDto[];
    addresses:SaveAddressDto[];
} 