import { updateStatus } from '@/api/EmployeeApi'
import { CommonStatus } from '@/enums/CommonStatus'
import { EmployeeTableProps } from '@/interface/props/EmployeeTableProps'
import { MaterialReactTable, useMaterialReactTable } from 'material-react-table';
import { EmployeeDtoTableColumns } from '../CustomTableColumns';
import React from 'react'

const EmployeeTable: React.FC<EmployeeTableProps> = ({ data, 
                                                       isLoading, 
                                                       pagination, 
                                                       setPagination, 
                                                       columnFilters,
                                                       setColumnFilters,
                                                       count }) => {

    const onClickUpdateStatus = (id:string, status:CommonStatus) => {
        updateStatus(id, { newStatus: status });
    }

    const table = useMaterialReactTable({
        columns: EmployeeDtoTableColumns(),
        data: data,
        state: {
            isLoading: isLoading, 
            pagination: pagination,
            showColumnFilters: true,
            columnFilters: columnFilters
        },

        // Loading
        muiCircularProgressProps: {
            color: 'primary',
            thickness: 5,
            size: 55,
        },
        muiSkeletonProps: {
            animation: 'pulse',
            height: 28,
        },

        // Pagination
        manualPagination: true,
        onPaginationChange: setPagination,
        rowCount: count,

        // Column Filters
        enableGlobalFilter: false,
        manualFiltering: true,
        onColumnFiltersChange: setColumnFilters,

        // Sticky
        enableStickyHeader: true,
        enableStickyFooter: true,

        // Row Numbers
        enableRowNumbers: true,
        rowNumberDisplayMode: 'static', // default
    });

    return <MaterialReactTable table={table}/>;
}

export default EmployeeTable