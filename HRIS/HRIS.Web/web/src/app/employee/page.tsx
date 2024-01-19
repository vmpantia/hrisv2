'use client'

import React, { useEffect, useState } from 'react'
import { EmployeeDto } from '@/interface/dtos/EmployeeDto';
import { EmployeeFilterPropertyType } from '@/enums/filter/EmployeeFilterPropertyType';
import EmployeeTable from '@/components/common/table/employee/EmployeeTable';
import { filterEmployeeListByFilter } from '@/api/EmployeeApi';

const page = () => {
    const [isLoading, setIsLoading] = useState(true);
    const [employeeList, setEmployeeList] = useState<EmployeeDto[]>([]);
    const [employeeFilter, setEmployeeFilter] = useState<ResourceFilter<EmployeeFilterPropertyType>>({
        filters: [],
        pagination: {
            pageNumber: 1,
            pageSize: 20,
        }
    })

    const fetchEmployeeList = () => {
        // Set loading state to true
        setIsLoading(true);

        // Get employee list by filter in API
        filterEmployeeListByFilter(employeeFilter)
            .then((res: EmployeeDto[]) => {
                // Set employee list based on the response
                setEmployeeList(res);

                // Set loading state to false
                setIsLoading(false);
            })
    }

    useEffect(() => {
        fetchEmployeeList();
    }, []);

    return (
        <>
            <div>Test Page</div>
            <EmployeeTable data={employeeList} 
                           isLoading={isLoading} />
        </>
    )
}

export default page