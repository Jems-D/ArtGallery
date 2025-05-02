import React from "react";
import { useAuth } from "../Context/useAuth";
import { Navigate, replace, useLocation } from "react-router-dom";
import { all } from "axios";

interface Props {
  children: React.ReactElement;
  allowedRoles: string[];
}

const ProtectedRoutes = ({ children, allowedRoles }: Props) => {
  const location = useLocation();
  const { isAuthenticated, user } = useAuth();

  if (!isAuthenticated()) {
    return <Navigate to="/unauthorized" state={{ from: location }} replace />;
  }
  if (!user || !allowedRoles.includes(user.role)) {
    return <Navigate to="forbidden" state={{ from: location }} replace />;
  }
  return <>{children}</>;
};

export default ProtectedRoutes;

{
  /*replace makes it so that user's can't go back to the original page they were in */
}
