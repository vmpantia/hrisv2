import { updateStatus } from '@/api/EmployeeApi'
import { CommonStatus } from '@/enums/CommonStatus'
import { EmployeeListProps } from '@/interface/props/EmployeeListProps'
import { MaterialReactTable } from 'material-react-table';
import { EmployeeDtoTableColumns } from '../common/table/CustomTableColumns';
import React from 'react'

const EmployeeList: React.FC<EmployeeListProps> = ({ data }) => {
    const onClickUpdateStatus = (id:string, status:CommonStatus) => {
        updateStatus(id, { newStatus: status });
    }

    return (
        <MaterialReactTable 
                columns={EmployeeDtoTableColumns()}
                data={data}/>
    )
}

export default EmployeeList