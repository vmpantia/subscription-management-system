import React from 'react'

const page = ({ params }: { params: { customerId: string } }) => {
    return (
        <div>{params.customerId} Customer Page</div>
    )
}

export default page