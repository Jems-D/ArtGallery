import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../Pages/HomePage";
import SearchPage from "../Pages/SearchPage";
import FavouritesPage from "../Pages/FavouritesPage";
import LoginPage from "../Pages/LoginPage";
import RegisterPage from "../Pages/RegisterPage";
import ProtectedRoutes from "./ProtectedRoutes";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      { path: "", element: <HomePage /> },
      {
        path: "search",
        element: (
          <ProtectedRoutes allowedRoles={["User"]}>
            <SearchPage />
          </ProtectedRoutes>
        ),
      },
      { path: "favs", element: <FavouritesPage /> },
      { path: "login", element: <LoginPage /> },
      { path: "register", element: <RegisterPage /> },
    ],
  },
]);
