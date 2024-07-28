import './App.css'
import {useCubeServiceGetApiV1CubeByUserId} from "../openapi/queries";

function App() {
  const {data, error, isLoading} = useCubeServiceGetApiV1CubeByUserId({
    userId: 1
  })
  
  if (isLoading) return <h1>Loading...</h1>
  
  if (!!error) {
    {error}
  }
  
  return <>
    {data?.map(c => <>{c.cubeName}</>)}
  </>
}

export default App
