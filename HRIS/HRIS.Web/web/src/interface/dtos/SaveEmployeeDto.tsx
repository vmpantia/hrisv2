interface SaveEmployeeDto {
    FirstName:string;
    MiddleName?:string;
    LastName:string;
    Gender:string;
    BirthDate:Date;
    Contacts:SaveContactDto[];
    Addresses:SaveAddressDto[];
} 