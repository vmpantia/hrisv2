import { EmployeeDto } from "../dtos/EmployeeDto";

export interface EmployeeTableProps {
    data: EmployeeDto[];
    isLoading: boolean;
}