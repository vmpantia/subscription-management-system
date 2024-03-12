import { TeamOutlined } from '@ant-design/icons'
import React from 'react'
import CustomSidebarButton from './CustomSidebarButton'

const CustomSidebar = () => {
    return (
        <aside id="logo-sidebar" className="fixed top-0 left-0 z-40 w-32 h-screen transition-transform -translate-x-ful sm:translate-x-0 bg-slate-800 border-slate-700" aria-label="Sidebar">
            <div className="h-full p-2 overflow-y-auto bg-slate-800">
                <ul className="space-y-2 font-medium">
                    <li>
                        <CustomSidebarButton name="Customers" icon={<TeamOutlined />} />
                        <CustomSidebarButton name="Subscriptions" icon={<TeamOutlined />} />
                    </li> 
                </ul>
            </div>
        </aside>
    )
}

export default CustomSidebar