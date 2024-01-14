import React from 'react'

const EmployeeList: React.FC<EmployeeListProps> = ({ employees }) => {
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
                {employees == null || employees.length == 0 ?
                    (
                        <tr>
                            <td colSpan={7}>
                                No Employees Found in the Database.
                            </td>
                        </tr>
                    )
                    :
                    (
                        employees.map((data, idx) => (
                            <tr key={data.Id}>
                                <td>{idx}</td>
                                <td>{data.Number}</td>
                                <td>{data.Name}</td>
                                <td>{data.Gender}</td>
                                <td>{data.BirthDate.getDate()}</td>
                                <td>{data.Age}</td>
                                <td>{data.Status}</td>
                            </tr>
                        ))
                    )
                }
            </tbody>
        </table>
    )
}

export default EmployeeList