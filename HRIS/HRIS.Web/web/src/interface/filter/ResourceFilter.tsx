interface ResourceFilter<TFilterPropertyType>{
    filters:CustomFilter<TFilterPropertyType>[];
    pagination:Pagination;
}