import { EmployeeDto } from "../dtos/EmployeeDto";

export interface EmployeeListProps {
    data: EmployeeDto[];
    hasUpdateStatusAction: boolean;
}