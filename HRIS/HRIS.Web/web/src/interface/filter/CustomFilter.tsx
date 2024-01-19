import { ConditionFilterType } from "@/enums/filter/ConditionFilterType";

export interface CustomFilter<TFilterPropertyType> {
    property:TFilterPropertyType;
    value?:string;
    condition:ConditionFilterType
}