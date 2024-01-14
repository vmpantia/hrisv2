import EmployeeList from '@/components/employee/EmployeeList'
import React from 'react'

const page = () => {
    return (
        <>
            <div>Test Page</div>
            <EmployeeList employees={[] as EmployeeDto[]} />
        </>
    )
}

export default page