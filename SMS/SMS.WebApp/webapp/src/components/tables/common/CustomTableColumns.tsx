import { SubscriptionViewModel } from "@/interfaces/viewmodels/subscription/SubscriptionViewModel";
import { Box } from "@mui/material";
import { MRT_ColumnDef } from "material-react-table";
import moment from "moment";

const defaultColumn = (header:string, key:string, colWidth:number = 150) => {
    return {
        id: key,
        header: header,
        size: colWidth,
        accessorKey: key
    }
}

const subscriptionAndProductNameColumn = (colWidth:number = 150) => {
    return {
        id: 'subscriptionAndProductName',
        header: 'Subscribed Product or Service',
        size: colWidth,
        accessorFn: (row:SubscriptionViewModel) => row.name === row.productName ? 
                                                        row.name : `${row.name} (${row.productName})`,
        enableColumnOrdering: false
    }
}

const dateColumnWithDueInDay = (header:string, key:string, colWidth:number = 150) => {
    return {
        id: key,
        header: header,
        size: colWidth,
        accessorFn: (row:any) => {
            let value = row[key];
            let dateValue = moment(value);
            let dateToday = moment().startOf('date');
            let dayDiff = dateValue.diff(dateToday, 'days');

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
                        <div className="w-full font-bold text-red-700">
                            Due Today
                        </div>
                    </>
                );
            
            // Check if the day difference is more than zero (due is not today)
            if(dayDiff > 0)
                return (
                    <>
                        <div className="w-full text-md font-bold">
                            {dateValue.format("YYYY-MM-DD")}
                        </div>
                        <div className="w-full font-bold text-green-700">
                            in {dayDiff} day(s)
                        </div>
                    </>
                );
        }
    }
}

const currencyColumn = (header:string, key:string, currency:string = "PHP", colWidth:number = 150) => {
    return {
        id: key,
        header: header,
        size: colWidth,
        accessorFn: (row:any) => {
            let value = row[key];
            return (
                <div className="text-md font-bold">
                    <label>{`${currency} ${value}`}</label>
                </div>
            )
        }
    }
}

const quantityColumn = (header:string, key:string, colWidth:number = 150) => {
    return {
        id: key,
        header: header,
        size: colWidth,
        accessorFn: (row:any) => {
            let value = row[key];
            return (
                <label>{value} <i>pc(s)</i></label>
            )
        }
    }
}

export const CustomerSubscriptionsTableColumn : MRT_ColumnDef<SubscriptionViewModel>[] = [
    subscriptionAndProductNameColumn(300) as MRT_ColumnDef<SubscriptionViewModel>,
    dateColumnWithDueInDay('Anniversary Date', 'anniversaryDate', 200) as MRT_ColumnDef<SubscriptionViewModel>,
    defaultColumn('Is Auto Renewal?', 'isAutomaticRenewal') as MRT_ColumnDef<SubscriptionViewModel>,
    quantityColumn('Quantity', 'quantity') as MRT_ColumnDef<SubscriptionViewModel>,
    defaultColumn('Subscription Cycle', 'subscriptionCycle') as MRT_ColumnDef<SubscriptionViewModel>,
    defaultColumn('Payment Cycle', 'paymentCycle') as MRT_ColumnDef<SubscriptionViewModel>,
    currencyColumn('Unit Price ₱', 'unitPrice') as MRT_ColumnDef<SubscriptionViewModel>,
    defaultColumn('Total ₱', 'total') as MRT_ColumnDef<SubscriptionViewModel>
]