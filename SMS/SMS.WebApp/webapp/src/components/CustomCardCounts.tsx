import { CustomCardCount, CustomCardCountProps } from '@/interfaces/props/CustomCardCountProps'
import React from 'react'

const CustomCardCounts : React.FC<CustomCardCountProps> = ({ cards }) => {
    const cardCount = (card:CustomCardCount) => 
        <div className="p-6 bg-white border border-slate-200 rounded-lg shadow">
            <h5 className="mb-5 pb-2 text-sm font-bold tracking-tight text-slate-700 border-b border-dashed border-slate-200">{card.title}</h5>
            <h1 className="text-4xl font-bold text-center text-slate-500">{card.count}</h1>
        </div>
    return (
        <div className='pb-2'>
            <div className='py-5 text-xl font-bold text-slate-700'>
                Summary
            </div>
            <div className="grid gap-4 grid-cols-1 xl:grid-cols-5 lg:grid-cols-4 md:grid-cols-3 sm:grid-cols-2">
                {cards.map(card => cardCount(card))}
            </div>
        </div>
    )
}

export default CustomCardCounts