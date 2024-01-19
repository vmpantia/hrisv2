import { updateStatus } from '@/api/EmployeeApi'
import { CommonStatus } from '@/enums/CommonStatus'
import { EmployeeTableProps } from '@/interface/props/EmployeeTableProps'
import { MRT_PaginationState, MaterialReactTable } from 'material-react-table';
import { EmployeeDtoTableColumns } from '../CustomTableColumns';
import React, { useState } from 'react'

const EmployeeTable: React.FC<EmployeeTableProps> = ({ data, isLoading, pagination, setPagination, count }) => {

    const onClickUpdateStatus = (id:string, status:CommonStatus) => {
        updateStatus(id, { newStatus: status });
    }

    return (
        <MaterialReactTable 
                columns={EmployeeDtoTableColumns()}
                data={data}
                state={{ isLoading: isLoading, 
                         pagination: pagination,
                }}
                onPaginationChange={setPagination}
                rowCount={count}
                manualPagination={true}
                muiCircularProgressProps={{
                    color: 'primary',
                    thickness: 5,
                    size: 55,
                }}
                muiSkeletonProps={{
                    animation: 'pulse',
                    height: 28,
                }}/>
    )
}

export default EmployeeTable