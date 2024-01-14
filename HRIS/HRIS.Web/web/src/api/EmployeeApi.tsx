import { axiosApi } from "./AxiosApi";

export const getEmployeeListByFilter = (request:ResourceFilter<EmployeeFilterPropertyType>) => 
    axiosApi.post<EmployeeDto[]>('/employees/filter', request).then(({data}) => data);

export const updateStatus = (id:string, request:UpdateCommonStatusDto) =>
    axiosApi.patch<string>(`/employees/${id}`, request).then(({data}) => data);