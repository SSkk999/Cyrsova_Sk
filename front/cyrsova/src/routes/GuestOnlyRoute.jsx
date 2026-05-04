
import { Navigate, Outlet } from "react-router-dom";

export default function GuestOnlyRoute() {
  const isAuth = !!localStorage.getItem("user");

  return isAuth ? <Navigate to="/" replace /> : <Outlet />;
}