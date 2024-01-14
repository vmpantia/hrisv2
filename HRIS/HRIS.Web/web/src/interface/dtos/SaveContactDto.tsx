interface SaveContactDto {
    Id?:string;
    Value:string;
    Type:ContactType;
    IsPrimary:boolean;
    IsPersonal:boolean;
}