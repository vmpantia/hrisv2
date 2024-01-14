import { CommonStatus } from "@/enums/CommonStatus";

export interface EmployeeDto {
    id:string;
    number:string;
    name:string;
    firstName:string;
    middleName?:string;
    lastName:string;
    gender:string;
    birthDate:Date;
    age:number;
    status:CommonStatus;
    statusDescription: string;
} 