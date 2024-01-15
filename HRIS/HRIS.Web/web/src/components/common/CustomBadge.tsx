import { CustomBadgeProps } from '@/interface/props/CustomBadgeProps'
import React from 'react'

const Badge: React.FC<CustomBadgeProps> = ({ value }) => {
    return (
        <span className='bg-slate-400 py-1 px-2 rounded-md text-xs font-bold'>
            {value}
        </span>
    )
}

export default Badge