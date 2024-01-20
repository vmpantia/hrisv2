import { EmployeeDto } from "../dtos/EmployeeDto";
import { Pagination } from "../filter/Pagination";

export interface EmployeeTableProps {
    data: EmployeeDto[];
    isLoading: boolean;
    pagination: any;
    setPagination: any;
    count: number;
}