interface SaveContactDto {
    id?:string;
    value:string;
    type:ContactType;
    isPrimary:boolean;
    isPersonal:boolean;
}