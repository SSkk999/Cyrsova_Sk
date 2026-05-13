import './App.css'
import { HEADER_ROUTES } from './constants'
import HomePage from './pages/Home'
import TestsPage from './pages/Tests'
import CarTest from "./pages/tests/CarTest";
import LoginPage from "./pages/Auth/LoginPage";
import RegisterPage from "./pages/Auth/RegistrPage";
import { ToastContainer } from "react-toastify";
import ProtectedRoute from "./routes/ProtectedRoute";
import GuestOnlyRoute from "./routes/GuestOnlyRoute";
import { Routes, Route, Navigate } from "react-router-dom";
import "react-toastify/dist/ReactToastify.css";
import Header from './components/Header'
import MyTestPage from './pages/MyTestPage';
import AddTestPage from './pages/tests/AddTestPage';
import AdminControlePage from './pages/AdminControlePage';
import RenamePage from './pages/Auth/RenemePage';
import RenameTestPage from './pages/tests/RenemeTestPage';
function App() {
  return (
    <>

      <Routes>
        <Route path={HEADER_ROUTES.HOME} element={<HomePage />} />

        <Route element={<GuestOnlyRoute />}>
          <Route path={HEADER_ROUTES.LOGIN} element={<LoginPage />} />
          <Route path={HEADER_ROUTES.REGISTER} element={<RegisterPage />} />
        </Route>

        <Route element={<ProtectedRoute />}>
        
          <Route path={HEADER_ROUTES.TESTS} element={<TestsPage />} />
          <Route path="/tests/tests/:id" element={<CarTest />} />
          <Route path={HEADER_ROUTES.MyTests} element={<MyTestPage />} />
          <Route path={HEADER_ROUTES.AddTest} element={<AddTestPage />} />
          <Route path={HEADER_ROUTES.AdminPanel} element={<AdminControlePage />} />
          <Route path={HEADER_ROUTES.Reneme} element={<RenamePage />} />
          <Route path={HEADER_ROUTES.RenemeTest} element={<RenameTestPage />} />
        </Route>

        <Route path="*" element={<Navigate to="/" replace />} />
      </Routes>

      <ToastContainer position="top-right" autoClose={2000} theme="dark" />
    </>
  )
}

export default App