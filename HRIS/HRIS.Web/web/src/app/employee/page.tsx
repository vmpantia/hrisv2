'use client'

import React, { useEffect, useState } from 'react'
import { getEmployeeListByFilter } from '@/api/EmployeeApi';
import EmployeeList from '@/components/employee/EmployeeList'
import { EmployeeDto } from '@/interface/dtos/EmployeeDto';
import { EmployeeFilterPropertyType } from '@/enums/filter/EmployeeFilterPropertyType';

const page = () => {
    const [employeeList, setEmployeeList] = useState<EmployeeDto[]>([]);
    const [employeeFilter, setEmployeeFilter] = useState<ResourceFilter<EmployeeFilterPropertyType>>({
        filters: [],
        pagination: {
            pageNumber: 1,
            pageSize: 20,
        }
    })

    const fetchEmployeeList = () => {
        // Get employee list by filter in API
        getEmployeeListByFilter(employeeFilter)
            .then((res: EmployeeDto[]) => {
                setEmployeeList(res);
            })
    }

    useEffect(() => {
        fetchEmployeeList();
    }, []);

    return (
        <>
            <div>Test Page</div>
            <EmployeeList data={employeeList} 
                            hasUpdateStatusAction={true} />
        </>
    )
}

export default page