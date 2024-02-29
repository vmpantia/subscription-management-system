import { MaterialReactTable, useMaterialReactTable } from 'material-react-table'
import React from 'react'

const CustomTable = ({  name,   
                        data, 
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
        enableColumnFilters: true,
        enableGlobalFilter: false,
        state: {
            isLoading: isLoading,
            columnPinning: {
                left: ['mrt-row-select', 'subscriptionAndProductName', 'customerName'],
            },
        },
        muiTableBodyProps:{
            sx: {
                '& .MuiTableCell-sizeMedium': {
                    color: 'rgb(51 65 85)',
                },
            },
        },
        muiTableHeadCellProps:{
            sx: {
                background: 'rgb(51 65 85)',
                color: 'rgb(255 255 255)'
            },
        },
    });

    return (
        
        <>
            <div className='py-5 text-xl font-bold text-slate-700'>
                {name}
            </div>
            <MaterialReactTable table={table}/>
        </>
    )
}

export default CustomTable