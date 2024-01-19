import { EmployeeDto } from "../dtos/EmployeeDto";
import { MRT_PaginationState } from "material-react-table";

export interface EmployeeTableProps {
    data: EmployeeDto[];
    isLoading: boolean;
    // MRT Pagination
    pagination: MRT_PaginationState;
    setPagination: any;
    count: number;
}