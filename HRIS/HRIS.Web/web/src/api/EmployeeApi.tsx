import { axiosAPI } from "./AxiosAPI";

export const getEmployeeListByFilter = (request: ResourceFilter<EmployeeFilterPropertyType>) => 
    axiosAPI.post<EmployeeDto[]>('/employees/filter', request).then(({data}) => data);