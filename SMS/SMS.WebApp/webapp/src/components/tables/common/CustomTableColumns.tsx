import { CustomerSubscriptionViewModel } from "@/interfaces/viewmodels/customer/CustomerSubscriptionViewModel";
import { CustomerViewModel } from "@/interfaces/viewmodels/customer/CustomerViewModel";
import { MailTwoTone, PhoneTwoTone } from "@mui/icons-material";
import { MRT_ColumnDef } from "material-react-table";
import moment from "moment";

const defaultSorting = (key:string, rowA:any, rowB:any) => {
    const dateA = rowA.original[key];
    const dateB = rowB.original[key];
    return dateA < dateB ?  1 : dateA > dateB ? -1 : 0;
}

const defaultFilterContains = (key:string, row:any, filterValue:any) =>
    row.original[key].toLowerCase().includes(filterValue.toLowerCase())

const defaultEqualContains = (key:string, row:any, filterValue:any) =>
    row.original[key] == filterValue;

const defaultColumn = (header:string, key:string, colWidth:number = 100, enableColumnOrdering:boolean = true) => {
    return {
        id: key,
        header: header,
        size: colWidth,
        accessorKey: key,
        enableColumnOrdering: enableColumnOrdering
    }
}

const subscribedProductColumn = (colWidth:number = 100, enableColumnOrdering:boolean = true) => {
    return {
        id: 'subscribed-product',
        header: 'Subscribed Product',
        size: colWidth,
        accessorFn: (row:any) => row.name === row.productName ? 
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
        sortingFn: (rowA:any, rowB:any) => defaultSorting(key, rowA, rowB),
        filterFn: (row:any, id:any, filterValue:any) => defaultFilterContains(key, row, filterValue),
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
        sortingFn: (rowA:any, rowB:any) => defaultSorting(key, rowA, rowB),
        filterFn: (row:any, id:any, filterValue:any) => defaultEqualContains(key, row, filterValue),
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
        sortingFn: (rowA:any, rowB:any) => defaultSorting(key, rowA, rowB),
        filterFn: (row:any, id:any, filterValue:any) => defaultEqualContains(key, row, filterValue),
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
        sortingFn: (rowA:any, rowB:any) => defaultSorting(key, rowA, rowB),
        filterFn: (row:any, id:any, filterValue:any) => defaultEqualContains(key, row, filterValue),
    }
}

const customerNameWithLinkColumn = (header:string, keyId:string, keyName:string, colWidth:number = 100, enableColumnOrdering:boolean = true) => {
    return {
        id: 'customer-name',
        header: header,
        size: colWidth,
        enableColumnOrdering: enableColumnOrdering,
        accessorFn: (row:any) => {
            let id = row[keyId];
            let name = row[keyName];
            return (
                <a href={`http://localhost:3000/customers/${id}`}
                    className="font-bold hover:text-slate-700">
                    {name}
                </a>
            )
        },
    }
}

const customerContactColumn = (colWidth:number = 100, enableColumnOrdering:boolean = true) => {
    return {
        id: 'customer-contact',
        header: 'Contact',
        size: colWidth,
        enableColumnOrdering: enableColumnOrdering,
        accessorFn: (row:any) => {
            let email = row.email;
            let telephone = row.telephone;
            return (
                <>
                    <div className="mb-1">
                        <MailTwoTone style={{width:'20px', marginRight: '10px'}} />
                        {email}
                    </div>
                    <div>
                        <PhoneTwoTone style={{width:'20px', marginRight: '10px'}} />
                        {telephone}
                    </div>
                </>
            )
        },
        filterFn: (row:any, id:any, filterValue:any) => {
            return row.original.email.toLowerCase().includes(filterValue.toLowerCase()) || 
                   row.original.telephone.toLowerCase().includes(filterValue.toLowerCase());
        }
    }
}

export const CustomerSubscriptionsTableColumn : MRT_ColumnDef<CustomerSubscriptionViewModel>[] = [
    subscribedProductColumn(300, false) as MRT_ColumnDef<CustomerSubscriptionViewModel>,
    dateColumnWithDueInDay('Anniversary Date', 'anniversaryDate', 200) as MRT_ColumnDef<CustomerSubscriptionViewModel>,
    statusColumn('Status', 'status') as MRT_ColumnDef<CustomerSubscriptionViewModel>,
    quantityColumn('Quantity', 'quantity') as MRT_ColumnDef<CustomerSubscriptionViewModel>,
    defaultColumn('Subscription Cycle', 'subscriptionCycle') as MRT_ColumnDef<CustomerSubscriptionViewModel>,
    defaultColumn('Payment Cycle', 'paymentCycle') as MRT_ColumnDef<CustomerSubscriptionViewModel>,
    currencyColumn('Unit Price', 'unitPrice') as MRT_ColumnDef<CustomerSubscriptionViewModel>,
    currencyColumn('Total', 'total') as MRT_ColumnDef<CustomerSubscriptionViewModel>,
    defaultColumn('Order', 'pendingOrderNumber') as MRT_ColumnDef<CustomerSubscriptionViewModel>
]

export const CustomerBillingSubscriptionsTableColumn : MRT_ColumnDef<CustomerSubscriptionViewModel>[] = [
    subscribedProductColumn(300, false) as MRT_ColumnDef<CustomerSubscriptionViewModel>,
    customerNameWithLinkColumn('Customer', 'customerId', 'customerName', 250, false) as MRT_ColumnDef<CustomerSubscriptionViewModel>,
    dateColumnWithDueInDay('Anniversary Date', 'anniversaryDate', 200) as MRT_ColumnDef<CustomerSubscriptionViewModel>,
    statusColumn('Status', 'status') as MRT_ColumnDef<CustomerSubscriptionViewModel>,
    quantityColumn('Quantity', 'quantity') as MRT_ColumnDef<CustomerSubscriptionViewModel>,
    defaultColumn('Subscription Cycle', 'subscriptionCycle') as MRT_ColumnDef<CustomerSubscriptionViewModel>,
    defaultColumn('Payment Cycle', 'paymentCycle') as MRT_ColumnDef<CustomerSubscriptionViewModel>,
    currencyColumn('Unit Price', 'unitPrice') as MRT_ColumnDef<CustomerSubscriptionViewModel>,
    currencyColumn('Total', 'total') as MRT_ColumnDef<CustomerSubscriptionViewModel>
]

export const CustomerTableColumn : MRT_ColumnDef<CustomerViewModel>[] = [
    customerNameWithLinkColumn('Name', 'id', 'name', 250) as MRT_ColumnDef<CustomerViewModel>,
    statusColumn('Status', 'status', 250) as MRT_ColumnDef<CustomerViewModel>,
    customerContactColumn() as MRT_ColumnDef<CustomerViewModel>,
    defaultColumn('No. of Subscriptions', 'noOfSubscriptions', 250) as MRT_ColumnDef<CustomerViewModel>,
]