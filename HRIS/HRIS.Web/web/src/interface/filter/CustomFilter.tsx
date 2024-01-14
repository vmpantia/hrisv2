interface CustomFilter<TFilterPropertyType> {
    property:TFilterPropertyType;
    value?:string;
    condition:ConditionFilterType
}