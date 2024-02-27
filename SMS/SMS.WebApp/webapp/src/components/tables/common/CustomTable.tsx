import { MaterialReactTable, useMaterialReactTable } from 'material-react-table'
import React from 'react'
import { BASE_COLORS } from '@/styles/themes/Constant'

const CustomTable = ({data, columns, enableSelection, isLoading}: any) => {
    const table = useMaterialReactTable({
        columns,
        data, //data must be memoized or stable (useState, useMemo, defined outside of this component, etc.)
        enableSelectAll: enableSelection,
        enableRowSelection: enableSelection,
        state: {
            isLoading: isLoading
        },
        muiTableBodyProps:{
            sx: {
                '& .MuiTableCell-sizeMedium': {
                    whiteSpace: "pre-wrap",
                    lineHeight: "25px",
                    borderBottom: `1px dashed ${BASE_COLORS.lightgrey}`,
                    color: BASE_COLORS.darkgrey,
                },
            },
        },
        muiTableHeadCellProps:{
            sx: {
                background: BASE_COLORS.pink,
                color: BASE_COLORS.white,
                // whiteSpace: "pre-wrap",
                '& .Mui-TableHeadCell-Content': {
                    justifyContent: 'left',
                },
            }
        }
    });

    return (
        <MaterialReactTable table={table}/>
    )
}

export default CustomTable