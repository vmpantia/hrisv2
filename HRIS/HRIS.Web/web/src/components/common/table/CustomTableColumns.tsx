import { EmployeeDto } from "@/interface/dtos/EmployeeDto";
import { MRT_ColumnDef } from "material-react-table";
import CustomBadge from "../CustomBadge";
import moment from "moment";

export const EmployeeDtoTableColumns = ():MRT_ColumnDef<EmployeeDto>[] => [
    GenerateNormalColumn('Id #', 'number', true, true) as MRT_ColumnDef<EmployeeDto>,
    GenerateNormalColumn('Name', 'name', true, false) as MRT_ColumnDef<EmployeeDto>,
    GenerateNormalColumn('Contact', 'primaryContact', true, false) as MRT_ColumnDef<EmployeeDto>,
    GenerateNormalColumn('Address', 'primaryAddress', true, false) as MRT_ColumnDef<EmployeeDto>,
    GenerateNormalColumn('Gender', 'gender', true, false) as MRT_ColumnDef<EmployeeDto>,
    GenerateBirthdateColumn('Birthdate', 'birthDate', true, false) as MRT_ColumnDef<EmployeeDto>,
    GenerateNormalColumn('Status', 'statusDescription', true, false) as MRT_ColumnDef<EmployeeDto>,
    GenerateNormalColumn('Action','action', false, false) as MRT_ColumnDef<EmployeeDto>,
];


// Custom Columns


const GenerateNormalColumn = (header:string, 
                              property:string, 
                              enableColFilter:boolean, 
                              enableClickToCopy:boolean,
                              size:number = 150) => {
    return {
        id: `${property}`,
        header: `${header}`,
        size: size,
        enableColumnFilter: enableColFilter,
        enableClickToCopy: enableClickToCopy,
        accessorFn: (row: any) => {
            return row[`${property}`] ?? '-';
        }
    };
}

const GenerateBirthdateColumn = (header:string, 
                                 property:string, 
                                 enableColFilter:boolean, 
                                 enableClickToCopy:boolean,
                                 size:number = 150) => {
    return {
        id: `${property}`,
        header: `${header}`,
        size: size,
        enableColumnFilter: enableColFilter,
        enableClickToCopy: enableClickToCopy,
        accessorFn: (row:any) => {
            const birthDate = moment(row[`${property}`]);
            const currentDate = moment().startOf('date');
            const age = birthDate.diff(currentDate, 'years');

            return (<div>
                        <p>{birthDate.format('YYYY-MM-DD')}</p>
                        <CustomBadge value={`${age} yr(s) old`} />
                    </div>);
        }
    };
}