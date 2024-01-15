import { EmployeeDto } from "@/interface/dtos/EmployeeDto";
import { MRT_ColumnDef } from "material-react-table";
import CustomBadge from "../CustomBadge";
import { differenceInYears, format } from "date-fns";

export const EmployeeDtoTableColumns = ():MRT_ColumnDef<EmployeeDto>[] => [
    {
        accessorFn: (row) => row.number,
        header: 'Id #',
        size: 150,
    },
    {
        accessorFn: (row) => row.name,
        header: 'Name',
        size: 150,
    },
    {
        accessorFn: (row) => row.gender,
        header: 'Gender',
        size: 200,
    },
    {
        accessorFn: (row) => row.birthDate,
        header: 'Birthdate',
        size: 150,
        Cell: ({ cell }) => (
            <div>
                {format(cell.getValue<Date>(), 'yyyy-MM-dd')}
                <br/>
                <CustomBadge value={`${differenceInYears(new Date(), cell.getValue<Date>())} yr(s) old`} />
            </div>
        ),
    },
    {
        accessorFn: (row) => row.statusDescription,
        header: 'Status',
        size: 150,
    },
    {
        header: 'Action',
        size: 150,
    },
];