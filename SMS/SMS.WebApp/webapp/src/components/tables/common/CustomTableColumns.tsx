import { SubscriptionViewModel } from "@/interfaces/viewmodels/subscription/SubscriptionViewModel";
import { ClassNames } from "@emotion/react";
import { Box } from "@mui/material";
import { MRT_ColumnDef } from "material-react-table";
import moment from "moment";

const defaultColumn = (header:string, key:string, colWidth:number = 100, enableColumnOrdering:boolean = true) => {
    return {
        id: key,
        header: header,
        size: colWidth,
        accessorKey: key,
        enableColumnOrdering: enableColumnOrdering
    }
}

const subscriptionAndProductNameColumn = (colWidth:number = 100, enableColumnOrdering:boolean = true) => {
    return {
        id: 'subscriptionAndProductName',
        header: 'Subscribed Product or Service',
        size: colWidth,
        accessorFn: (row:SubscriptionViewModel) => row.name === row.productName ? 
                                                        row.name : `${row.name} (${row.productName})`,
        enableColumnOrdering: enableColumnOrdering
    }
}

const dateColumnWithDueInDay = (header:string, key:string, colWidth:number = 100, enableColumnOrdering:boolean = true) => {
    return {
        id: key,
        header: header,
        size: colWidth,
        enableColumnOrdering: enableColumnOrdering,
        accessorFn: (originalRow:any) => {
            const value = originalRow[key];
            const dateValue = moment(value);
            const dateToday = moment().startOf('date');
            const dayDiff = dateValue.diff(dateToday, 'days');

            // Check if the values are valid
            if(dateToday == undefined || dateValue == undefined || value == "0001-01-01T00:00:00") 
                return ("");

            // Check if the day difference is less than zero (already due date)
            if(dayDiff < 0)
                return (
                    <label className="text-md font-bold text-red-700">
                        {dateValue.format("YYYY-MM-DD")}
                    </label>
                );
            // Check if the day difference is equal to zero (due today)
            if(dayDiff == 0)
                return (
                    <>
                        <div className="w-full text-md font-bold">
                            {dateValue.format("YYYY-MM-DD")}
                        </div>
                        <span className="inline-flex items-center rounded-md bg-red-50 px-2 py-1 text-xs font-bold text-red-700 ring-1 ring-inset ring-red-600/10">
                            Due Today
                        </span>
                    </>
                );
            
            // Check if the day difference is more than zero (due is not today)
            if(dayDiff > 0)
                return (
                    <>
                        <div className="w-full text-md font-bold">
                            {dateValue.format("YYYY-MM-DD")}
                        </div>
                        <span className="inline-flex items-center rounded-md bg-green-50 px-2 py-1 text-xs font-bold text-green-700 ring-1 ring-inset ring-green-600/20">
                            in {dayDiff} day(s)
                        </span>
                    </>
                );
        },
        sortingFn: (rowA:any, rowB:any) => {
            const dateA = rowA.original[key];
            const dateB = rowB.original[key];
            return dateA < dateB ?  1 : dateA > dateB ? -1 : 0;
        },
        filterFn: (row:any, id:any, filterValue:any) => {
            return row.original[key].toLowerCase().includes(filterValue.toLowerCase())
        }
    }
}

const currencyColumn = (header:string, key:string, currency:string = "PHP", colWidth:number = 100, enableColumnOrdering:boolean = true) => {
    return {
        id: key,
        header: header,
        size: colWidth,
        enableColumnOrdering: enableColumnOrdering,
        accessorFn: (row:any) => {
            let value = row[key].toLocaleString('en-US', { style: 'currency', currency: currency });;
            return (
                <>
                    <div className="w-full text-md font-bold pb-1">
                        {value}
                    </div>
                    <span className="inline-flex items-center rounded-md bg-slate-50 px-2 py-1 text-xs font-bold text-slate-600 ring-1 ring-inset ring-slate-500/10">
                        {currency}
                    </span>
                </>
            )
        },
        sortingFn: (rowA:any, rowB:any) => {
            const dateA = rowA.original[key];
            const dateB = rowB.original[key];
            return dateA < dateB ?  1 : dateA > dateB ? -1 : 0;
        },
        filterFn: (row:any, id:any, filterValue:any) => {
            return row.original[key] == filterValue;
        }
    }
}

const quantityColumn = (header:string, key:string, colWidth:number = 100, enableColumnOrdering:boolean = true) => {
    return {
        id: key,
        header: header,
        size: colWidth,
        enableColumnOrdering: enableColumnOrdering,
        accessorFn: (row:any) => {
            let value = row[key];
            return (
                <label>{value} <i>pc(s)</i></label>
            )
        },
        sortingFn: (rowA:any, rowB:any) => {
            const dateA = rowA.original[key];
            const dateB = rowB.original[key];
            return dateA < dateB ?  1 : dateA > dateB ? -1 : 0;
        },
        filterFn: (row:any, id:any, filterValue:any) => {
            return row.original[key] == filterValue;
        }
    }
}

const statusColumn = (header:string, key:string, colWidth:number = 100, enableColumnOrdering:boolean = true) => {
    return {
        id: key,
        header: header,
        size: colWidth,
        enableColumnOrdering: enableColumnOrdering,
        accessorFn: (row:any) => {
            let value = row[key];
            let style = "";
            switch(value) {
                case 'Expired':
                case 'Cancelled':
                    style = "inline-flex items-center rounded-md bg-red-50 px-2 py-1 text-sm font-bold text-red-700 ring-1 ring-inset ring-red-600/10";
                    break;
                case 'Active':
                    style = "inline-flex items-center rounded-md bg-green-50 px-2 py-1 text-sm font-bold text-green-700 ring-1 ring-inset ring-green-600/20";
                    break;
                case 'Inactive':
                    style = "inline-flex items-center rounded-md bg-gray-50 px-2 py-1 text-sm font-bold text-gray-600 ring-1 ring-inset ring-gray-500/10";
                    break;
            }
            return (<span className={style}>{value}</span>)
        },
        sortingFn: (rowA:any, rowB:any) => {
            const dateA = rowA.original[key];
            const dateB = rowB.original[key];
            return dateA < dateB ?  1 : dateA > dateB ? -1 : 0;
        },
        filterFn: (row:any, id:any, filterValue:any) => {
            return row.original[key] == filterValue;
        }
    }
}

export const CustomerSubscriptionsTableColumn : MRT_ColumnDef<SubscriptionViewModel>[] = [
    subscriptionAndProductNameColumn(300, false) as MRT_ColumnDef<SubscriptionViewModel>,
    dateColumnWithDueInDay('Anniversary Date', 'anniversaryDate', 200) as MRT_ColumnDef<SubscriptionViewModel>,
    statusColumn('Status', 'status') as MRT_ColumnDef<SubscriptionViewModel>,
    quantityColumn('Quantity', 'quantity') as MRT_ColumnDef<SubscriptionViewModel>,
    defaultColumn('Subscription Cycle', 'subscriptionCycle') as MRT_ColumnDef<SubscriptionViewModel>,
    defaultColumn('Payment Cycle', 'paymentCycle') as MRT_ColumnDef<SubscriptionViewModel>,
    currencyColumn('Unit Price', 'unitPrice') as MRT_ColumnDef<SubscriptionViewModel>,
    currencyColumn('Total', 'total') as MRT_ColumnDef<SubscriptionViewModel>
]

export const CustomerBillingSubscriptionsTableColumn : MRT_ColumnDef<SubscriptionViewModel>[] = [
    subscriptionAndProductNameColumn(300, false) as MRT_ColumnDef<SubscriptionViewModel>,
    defaultColumn('Customer', 'customerName', 250) as MRT_ColumnDef<SubscriptionViewModel>,
    dateColumnWithDueInDay('Anniversary Date', 'anniversaryDate', 200) as MRT_ColumnDef<SubscriptionViewModel>,
    statusColumn('Status', 'status') as MRT_ColumnDef<SubscriptionViewModel>,
    quantityColumn('Quantity', 'quantity') as MRT_ColumnDef<SubscriptionViewModel>,
    defaultColumn('Subscription Cycle', 'subscriptionCycle') as MRT_ColumnDef<SubscriptionViewModel>,
    defaultColumn('Payment Cycle', 'paymentCycle') as MRT_ColumnDef<SubscriptionViewModel>,
    currencyColumn('Unit Price', 'unitPrice') as MRT_ColumnDef<SubscriptionViewModel>,
    currencyColumn('Total', 'total') as MRT_ColumnDef<SubscriptionViewModel>
]