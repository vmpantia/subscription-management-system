import { MaterialReactTable, useMaterialReactTable } from 'material-react-table'
import React from 'react'
import { BASE_COLORS } from '@/styles/themes/Constant'

const CustomTable = ({  data, 
                        columns, 
                        isLoading, 
                        enableRowSelection, 
                        enableTopToolbar = true, 
                        enableBottomToolbar = true,
                        enableColumnOrdering = true,
                    }: any) => {
    const table = useMaterialReactTable({
        columns,
        data, 
        enableSelectAll: enableRowSelection,
        enableRowSelection: enableRowSelection,
        enableTopToolbar: enableTopToolbar,
        enableBottomToolbar: enableBottomToolbar,
        enableColumnOrdering: enableColumnOrdering,
        state: {
            isLoading: isLoading,
            columnPinning: {
                left: ['mrt-row-expand', 'mrt-row-select'],
                right: ['mrt-row-actions'],
            },
        },
        muiTableBodyProps:{
            sx: {
                '& .MuiTableCell-sizeMedium': {
                    whiteSpace: "pre-wrap",
                    lineHeight: "25px",
                    borderBottom: `1px dashed ${BASE_COLORS.lightgrey}`,
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