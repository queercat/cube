import React, {ReactNode, useMemo} from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './index.css'
import {QueryClient, QueryClientProvider} from "@tanstack/react-query";

ReactDOM.createRoot(document.getElementById('root')!).render((() => {
        const queryClient = new QueryClient({
            defaultOptions: {
                queries: {
                }
            }
        })
    
        return (
            <React.StrictMode>
                <QueryClientProvider client={queryClient}>
                    <App/>
                </QueryClientProvider>
            </React.StrictMode>
        )
    })()
)
