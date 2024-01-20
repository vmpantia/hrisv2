import { ConditionFilterType } from "@/enums/filter/ConditionFilterType";
import { EmployeeFilterPropertyType } from "@/enums/filter/EmployeeFilterPropertyType";
import { CustomFilter } from "@/interface/filter/CustomFilter";
import { Pagination } from "@/interface/filter/Pagination";
import { MRT_ColumnFiltersState, MRT_PaginationState } from "material-react-table";

export const ConvertMRTPagination = (mrtPagination: MRT_PaginationState) : Pagination => {
    return { pageIndex: mrtPagination.pageIndex, pageSize: mrtPagination.pageSize };
}

export const ConvertMRTColumnFilters = (mrtColumnFilters: MRT_ColumnFiltersState) : CustomFilter<EmployeeFilterPropertyType>[] => {
    let filters:CustomFilter<EmployeeFilterPropertyType>[] = [];

    // Remove all the filters that have value NULL
    mrtColumnFilters.filter((item:any) => item.value != null)
                    .map((item:any) => {
        switch(item.id){
            case "number":
                filters.push({ property: EmployeeFilterPropertyType.Id, value: item.value, condition: ConditionFilterType.Contains });
                break;

            case "name":
                filters.push({ property: EmployeeFilterPropertyType.FName, value: item.value, condition: ConditionFilterType.Contains });
                break;

            case "gender":
                filters.push({ property: EmployeeFilterPropertyType.Gender, value: item.value, condition: ConditionFilterType.Equals });
                break;
        }
    });

    return filters;
}