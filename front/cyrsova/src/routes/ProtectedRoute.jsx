
import { Navigate, Outlet } from "react-router-dom";
import Header from "../components/Header";

export default function ProtectedRoute() {
  const isAuth = !!localStorage.getItem("user");

  return isAuth ?        <>
      <Header />
      <Outlet />
    </> : <Navigate to="/login" replace />;
}