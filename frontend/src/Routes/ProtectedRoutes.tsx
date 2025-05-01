import React from "react";
import { userAuth } from "../Context/useAuth";
import { Navigate, useLocation } from "react-router-dom";

interface Props {
  children: React.ReactElement;
  allowedRoles: string[];
}

const ProtectedRoutes = ({ children, allowedRoles }: Props) => {
  const location = useLocation();
  const { isAuthenticated, user } = userAuth();

  return isAuthenticated() &&
    allowedRoles.includes(user ? user.role : "none") ? (
    <>{children}</>
  ) : (
    <Navigate to="/login" state={{ from: location }} replace />
  );
};

export default ProtectedRoutes;

{
  /*replace makes it so that user's can't go back to the original page they were in */
}
