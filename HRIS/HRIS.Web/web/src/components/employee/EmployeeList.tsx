import { format } from 'date-fns'
import React from 'react'

const EmployeeList: React.FC<EmployeeListProps> = ({ data }) => {
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
                                <td>{employee.status}</td>
                            </tr>
                        ))
                    )
                }
            </tbody>
        </table>
    )
}

export default EmployeeList