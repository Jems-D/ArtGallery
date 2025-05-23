import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../Pages/HomePage";
import SearchPage from "../Pages/SearchPage";
import FavouritesPage from "../Pages/FavouritesPage";
import LoginPage from "../Pages/LoginPage";
import RegisterPage from "../Pages/RegisterPage";
import ProtectedRoutes from "./ProtectedRoutes";
import UnauthorizedPage from "../Pages/UnauthorizedPage";
import ForbiddenPage from "../Pages/ForbiddenPage";
import ObjectProfilePage from "../Pages/ObjectProfilePage";
import Publications from "../Components/Publications/Publications";
import Exhibitions from "../Components/Exhibitions/Exhibitions";
import CategoriesPage from "../Pages/CategoriesPage";
import CardList from "../Components/CardList/CardList";
import CardArtworks from "../Components/CardList/CardArtworks";
import NotFoundPage from "../Pages/NotFoundPage";
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
      {
        path: "categories/:category",
        element: <CategoriesPage />,
      },
      {
        path: "categories/:category/:id",
        element: <CardArtworks />,
      },
      {
        path: "obj/:objectid",
        element: <ObjectProfilePage />,
        children: [
          { path: "publications", element: <Publications /> },
          { path: "exhibitions", element: <Exhibitions /> },
        ],
      },
      { path: "favs", element: <FavouritesPage /> },
      { path: "login", element: <LoginPage /> },
      { path: "register", element: <RegisterPage /> },
      { path: "unauthorized", element: <UnauthorizedPage /> },
      { path: "forbidden", element: <ForbiddenPage /> },
      { path: "*", element: <NotFoundPage /> },
    ],
  },
]);
