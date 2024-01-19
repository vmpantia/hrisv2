'use client'

import React, { useEffect, useState } from 'react'
import { EmployeeDto } from '@/interface/dtos/EmployeeDto';
import { EmployeeFilterPropertyType } from '@/enums/filter/EmployeeFilterPropertyType';
import EmployeeTable from '@/components/common/table/employee/EmployeeTable';
import { filterEmployeeListByFilter } from '@/api/EmployeeApi';
import { ResourceFilter } from '@/interface/filter/ResourceFilter';
import { MRT_PaginationState } from 'material-react-table';

const page = () => {
    const [isLoading, setIsLoading] = useState(true);
    const [employeeList, setEmployeeList] = useState<EmployeeDto[]>([]);
    const [countEmployeeFilter, setCountEmployeeFilter] = useState(0);
    const [employeeFilter, setEmployeeFilter] = useState<ResourceFilter<EmployeeFilterPropertyType>>({
        filters: [],
        pagination: {
            pageNumber: 1,
            pageSize: 10,
        }
    })

    const [mrtPagination, setMrtPagination] = useState<MRT_PaginationState>({
        pageIndex: 0,
        pageSize: 10,
    });

    const fetchEmployeeList = () => {
        // Set loading state to true
        setIsLoading(true);

        // Get employee list by filter in API
        filterEmployeeListByFilter(employeeFilter)
            .then((res: any) => {
                // Set filtered and paginated employees based on the response
                setEmployeeList(res.data);

                // Set number of filtered employees
                setCountEmployeeFilter(res.count);

                // Set loading state to false
                setIsLoading(false);
            })
    }

    useEffect(() => {
        fetchEmployeeList();
    }, []);

    useEffect(() => {
        setEmployeeFilter(data => ({
            ...data,
            pagination: {
                pageNumber: mrtPagination.pageIndex + 1,
                pageSize: mrtPagination.pageSize,
            },
        }));

        fetchEmployeeList();
    }, [mrtPagination.pageIndex, mrtPagination.pageSize]);

    return (
        <>
            <div>Test Page</div>
            <EmployeeTable data={employeeList} 
                           isLoading={isLoading}
                           pagination={mrtPagination}
                           setPagination={setMrtPagination}
                           count={countEmployeeFilter} />
        </>
    )
}

export default page