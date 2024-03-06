import { CustomCardCount, CustomCardCountProps } from '@/interfaces/props/CustomCardCountProps'
import React from 'react'

const CustomCardCounts : React.FC<CustomCardCountProps> = ({ cards, isLoading }) => {
    const cardCount = (card:CustomCardCount) => 
        isLoading ?
            <div className="p-6 bg-white rounded-lg drop-shadow-md">
                <div className="animate-pulse flex space-x-4">
                    <div className="flex-1 space-y-6 py-1">
                        <div className="h-5 mb-5 bg-stone-200 rounded"></div>
                        <div className="h-11 bg-stone-200 rounded"></div>
                    </div>
                </div>
            </div> 
            :
            <div className="p-6 bg-white rounded-lg drop-shadow-md">
                <h5 className="mb-2 text-base font-bold tracking-tight text-slate-700">{card.title}</h5>
                <h1 className="p-3 text-5xl font-bold text-center text-slate-500">{card.count}</h1>
            </div> 
        
    return (
        <div>
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