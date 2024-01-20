'use client'

import React, { useEffect, useState } from 'react'
import { EmployeeDto } from '@/interface/dtos/EmployeeDto';
import { EmployeeFilterPropertyType } from '@/enums/filter/EmployeeFilterPropertyType';
import EmployeeTable from '@/components/common/table/employee/EmployeeTable';
import { filterEmployeeListByFilter } from '@/api/EmployeeApi';
import { ResourceFilter } from '@/interface/filter/ResourceFilter';
import { MRT_ColumnFiltersState, MRT_PaginationState } from 'material-react-table';
import { ConvertMRTColumnFilters, ConvertMRTPagination } from '@/helpers/ConversionHelper';

const page = () => {
    const [isLoading, setIsLoading] = useState(true);
    const [employeeList, setEmployeeList] = useState<EmployeeDto[]>([]);

    // Filter and Pagination related variables
    const [mrtColumnFilters, setMrtColumnFilters] = useState<MRT_ColumnFiltersState>([]);
    const [mrtPagination, setMrtPagination] = useState<MRT_PaginationState>({ pageIndex: 0, pageSize: 10 });
    const [countFilteredData, setCountFilteredData] = useState(0);

    const fetchEmployeeList = () => {
        // Set loading state to true
        setIsLoading(true);

        // Prepare payload for filter employee
        let payload:ResourceFilter<EmployeeFilterPropertyType> = {
            filters: ConvertMRTColumnFilters(mrtColumnFilters),
            pagination: ConvertMRTPagination(mrtPagination),
        };

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
        // Get new batch of employee list based on the filters
        fetchEmployeeList();
    }, [mrtPagination.pageIndex, mrtPagination.pageSize, mrtColumnFilters]);

    return (
        <>
            <EmployeeTable data={employeeList} 
                           isLoading={isLoading}
                           pagination={mrtPagination}
                           setPagination={setMrtPagination}
                           columnFilters={mrtColumnFilters}
                           setColumnFilters={setMrtColumnFilters}
                           count={countFilteredData} />
        </>
    )
}

export default page