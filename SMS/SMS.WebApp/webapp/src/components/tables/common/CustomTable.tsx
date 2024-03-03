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
        enableRowNumbers: true,
        enableRowSelection: enableRowSelection,
        enableTopToolbar: enableTopToolbar,
        enableBottomToolbar: enableBottomToolbar,
        enableColumnOrdering: enableColumnOrdering,
        enableColumnFilters: true,
        enableGlobalFilter: false,
        state: {
            isLoading: isLoading,
            columnPinning: {
                left: ['mrt-row-select', 'mrt-row-numbers', 'subscribed-product', 'customer-name'],
            },
        },
        muiTableBodyProps:{
            sx: {
                '& .MuiTableCell-sizeMedium': {
                    color: 'rgb(100 116 139)',
                },
            },
        },
        muiTableHeadCellProps:{
            sx: {
                background: 'rgb(51 65 85)',
                color: 'white'
            },
        },
        muiCircularProgressProps: {
            thickness: 4,
            size: 40,
            style: {
                marginTop: 50,
                color: 'rgb(51 65 85)'
            }
        }
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