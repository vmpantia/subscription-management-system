import React from 'react'

const CustomSidebarButton = ({name, icon}: any) => {
    return (
        <a href="http://localhost:3000/customers/" className="flex items-center p-2 font-normal rounded-lg text-white hover:bg-slate-700 group">
            <div className='w-full text-center'>
                <div className='text-2xl mb-2'>  
                    {icon} 
                </div>
                <span className="text-xs">{name}</span>
            </div>
        </a>
    )
}

export default CustomSidebarButton