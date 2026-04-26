import './App.css'
import { HEADER_ROUTES } from './constants'
import HomePage from './pages/Home'
import TestsPage from './pages/Tests'
import CarTest from "./pages/tests/CarTest";

import { BrowserRouter, Routes, Route } from "react-router-dom"

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path={HEADER_ROUTES.HOME} element={<HomePage />} />
        <Route path={HEADER_ROUTES.TESTS} element={<TestsPage />} />
        <Route path="/tests/car" element={<CarTest />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App