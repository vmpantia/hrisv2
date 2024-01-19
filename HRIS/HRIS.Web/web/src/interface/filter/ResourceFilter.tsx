import { CustomFilter } from "./CustomFilter";
import { Pagination } from "./Pagination";

export interface ResourceFilter<TFilterPropertyType>{
    filters:CustomFilter<TFilterPropertyType>[];
    pagination:Pagination;
}