import { EmployeeDto } from "@/interface/dtos/EmployeeDto";
import { MRT_ColumnDef } from "material-react-table";
import CustomBadge from "../CustomBadge";
import { differenceInYears, format } from "date-fns";
import moment from "moment";

export const EmployeeDtoTableColumns = ():MRT_ColumnDef<EmployeeDto>[] => [
    GenerateNormalColumn('Id #', 'number') as MRT_ColumnDef<EmployeeDto>,
    GenerateNormalColumn('Name', 'name') as MRT_ColumnDef<EmployeeDto>,
    GenerateNormalColumn('Contact', 'primaryContact') as MRT_ColumnDef<EmployeeDto>,
    GenerateNormalColumn('Address', 'primaryAddress') as MRT_ColumnDef<EmployeeDto>,
    GenerateNormalColumn('Gender', 'gender') as MRT_ColumnDef<EmployeeDto>,
    GenerateBirthdateColumn('Birthdate', 'birthDate') as MRT_ColumnDef<EmployeeDto>,
    GenerateNormalColumn('Status', 'statusDescription') as MRT_ColumnDef<EmployeeDto>,
    GenerateNormalColumn('Action') as MRT_ColumnDef<EmployeeDto>,
];


// Custom Columns
const GenerateNormalColumn = (header:string, property:string = '', size:number = 150) => {
    return {
        header: header,
        size: size,
        accessorFn: (row:any) => {
            return row[property] ?? '-';
        }
    }
}

const GenerateBirthdateColumn = (header:string, property:string = '', size:number = 150) => {
    return {
        header: header,
        size: size,
        accessorFn: (row:any) => {
            const birthDate = moment(row.birthDate)
            const currentDate = moment().startOf('date')
            const age = birthDate.diff(currentDate, 'years')

            return (<div>
                        <p>{birthDate.format('YYYY-MM-DD')}</p>
                        <CustomBadge value={`${age} yr(s) old`} />
                    </div>)
        }
    }

}