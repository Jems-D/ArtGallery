import React from "react";
import SVG from "../Components/SVG/SVG";
import forbidden from "../Components/SVG/forbidden.svg";
import { useLoaderData, useLocation } from "react-router-dom";
type Props = {};

const ForbiddenPage = (props: Props) => {
  const location = useLocation();
  const from = location.state?.from?.pathname || "";
  return (
    <article className="w-full h-[100vh] grid place-items-center">
      <SVG image={forbidden} />
      <span className="font-sans text-base text-wrap dark:text-gray-500">
        You were trying to access a location that is only accessible to higher
        roles,
        {from}
      </span>
    </article>
  );
};

export default ForbiddenPage;
