import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import HomePage from "../Pages/HomePage";
import SearchPage from "../Pages/SearchPage";
import FavouritesPage from "../Pages/FavouritesPage";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <App />,
    children: [
      { path: "", element: <HomePage /> },
      { path: "search", element: <SearchPage /> },
      { path: "favs", element: <FavouritesPage /> },
    ],
  },
]);
