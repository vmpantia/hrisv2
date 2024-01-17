import { CustomBadgeProps } from '@/interface/props/CustomBadgeProps'
import React from 'react'

const Badge: React.FC<CustomBadgeProps> = ({ value }) => {
    return (
        <span className='drop-shadow-md bg-blue-800 py-0.5 px-3 rounded-lg text-xs text-white'>
            {value}
        </span>
    )
}

export default Badge