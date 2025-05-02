import React from "react";
import SVG from "../Components/SVG/SVG";
import unauthorized from "../Components/SVG/unauthorized.svg";
import { Link, useLoaderData, useLocation } from "react-router-dom";
type Props = {};

const UnauthorizedPage = (props: Props) => {
  const location = useLocation();
  const from = location.state?.from?.pathname || "";
  return (
    <article className="w-[100vw] h-[100vh] grid place-items-center">
      <Link to="/login">
        <SVG image={unauthorized} />
      </Link>
      <span className="font-sans text-base text-wrap dark:text-gray-500">
        You were trying to access a location that is only accessible to users,
        {from}, click the image to login.
      </span>
    </article>
  );
};

export default UnauthorizedPage;
