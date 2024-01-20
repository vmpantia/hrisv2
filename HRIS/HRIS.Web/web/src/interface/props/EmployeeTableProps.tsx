import { EmployeeFilterPropertyType } from "@/enums/filter/EmployeeFilterPropertyType";
import { EmployeeDto } from "../dtos/EmployeeDto";
import { CustomFilter } from "../filter/CustomFilter";
import { Pagination } from "../filter/Pagination";
import { MRT_ColumnFiltersState } from "material-react-table";

export interface EmployeeTableProps {
    data: EmployeeDto[];
    isLoading: boolean;

    // Pagination
    pagination: Pagination;
    setPagination: any;
    
    // Column Filters
    columnFilters: MRT_ColumnFiltersState;
    setColumnFilters: any;

    count: number;
}