'use client'

import React, { useEffect, useState } from 'react'
import { EmployeeDto } from '@/interface/dtos/EmployeeDto';
import { EmployeeFilterPropertyType } from '@/enums/filter/EmployeeFilterPropertyType';
import EmployeeTable from '@/components/common/table/employee/EmployeeTable';
import { filterEmployeeListByFilter } from '@/api/EmployeeApi';
import { Pagination } from '@/interface/filter/Pagination';
import { CustomFilter } from '@/interface/filter/CustomFilter';
import { ResourceFilter } from '@/interface/filter/ResourceFilter';

const page = () => {
    const [isLoading, setIsLoading] = useState(true);
    const [employeeList, setEmployeeList] = useState<EmployeeDto[]>([]);

    // Filter and Pagination related variables
    const [pagination, setPagination] = useState<Pagination>({ pageIndex: 0, pageSize: 10 });
    const [filters, setFilters] = useState<CustomFilter<EmployeeFilterPropertyType>[]>([]);
    const [countFilteredData, setCountFilteredData] = useState(0);

    const fetchEmployeeList = () => {
        // Prepare payload for filter employee
        let payload:ResourceFilter<EmployeeFilterPropertyType> = {
            filters: filters,
            pagination: pagination,
        };

        // Set loading state to true
        setIsLoading(true);

        // Get employee list by filter in API
        filterEmployeeListByFilter(payload)
            .then((res: any) => {
                // Set filtered and paginated employees based on the response
                setEmployeeList(res.data);

                // Set number of filtered employees
                setCountFilteredData(res.countFilteredData);

                // Set loading state to false
                setIsLoading(false);
            })
    }

    useEffect(() => {
        fetchEmployeeList();
    }, []);

    useEffect(() => {
        fetchEmployeeList();
    }, [pagination.pageIndex, pagination.pageSize]);

    return (
        <>
            <EmployeeTable data={employeeList} 
                           isLoading={isLoading}
                           pagination={pagination}
                           setPagination={setPagination}
                           count={countFilteredData} />
        </>
    )
}

export default page