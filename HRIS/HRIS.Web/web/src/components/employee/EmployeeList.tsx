import { updateStatus } from '@/api/EmployeeApi'
import { CommonStatus } from '@/enums/CommonStatus'
import { EmployeeListProps } from '@/interface/props/EmployeeListProps'
import { format } from 'date-fns'
import React from 'react'

const EmployeeList: React.FC<EmployeeListProps> = ({ data }) => {

    const onClickUpdateStatus = (id:string, status:CommonStatus) => {
        updateStatus(id, { newStatus: status });
    }

    return (
        <table>
            <thead>
                <tr>
                    <th>No.</th>
                    <th>Id</th>
                    <th>Name</th>
                    <th>Gender</th>
                    <th>BirthDate</th>
                    <th>Age</th>
                    <th>Status</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
                {data == null || data.length == 0 ?
                    (
                        <tr>
                            <td colSpan={7}>
                                No Employees Found in the Database.
                            </td>
                        </tr>
                    )
                    :
                    (
                        data.map((employee, idx) => (
                            <tr key={employee.id}>
                                <td>{idx + 1}</td>
                                <td>{employee.number}</td>
                                <td>{employee.name}</td>
                                <td>{employee.gender}</td>
                                <td>{format(employee.birthDate, "yyyy-MM-dd")}</td>
                                <td>{employee.age}</td>
                                <td>{employee.statusDescription}</td>
                                <td>
                                    <button onClick={() => onClickUpdateStatus(employee.id, employee.status == CommonStatus.Active ? CommonStatus.Inactive : CommonStatus.Active)}>
                                        {employee.status == CommonStatus.Active ? 'Incative' : 'Active' }
                                    </button>
                                    <button onClick={() => onClickUpdateStatus(employee.id, CommonStatus.Deleted)}>Delete</button>
                                </td>
                            </tr>
                        ))
                    )
                }
            </tbody>
        </table>
    )
}

export default EmployeeList