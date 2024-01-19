import { EmployeeFilterPropertyType } from "@/enums/filter/EmployeeFilterPropertyType";
import { EmployeeDto } from "@/interface/dtos/EmployeeDto";
import { UpdateCommonStatusDto } from "@/interface/dtos/UpdateCommonStatusDto";
import { axiosApi } from "./AxiosAPI";

export const filterEmployeeListByFilter = (request:ResourceFilter<EmployeeFilterPropertyType>) => 
    axiosApi.post<EmployeeDto[]>('/employees/filter', request).then(({data}) => data);

export const updateStatus = (id:string, request:UpdateCommonStatusDto) =>
    axiosApi.patch<string>(`/employees/${id}`, request).then(({data}) => data);