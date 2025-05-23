import React from "react";
import { Link, useLocation } from "react-router-dom";
import SVG from "../Components/SVG/SVG";
import notFound from "../Components/SVG/notfound.svg";

type Props = {};

const NotFoundPage = (props: Props) => {
  const location = useLocation();
  const from = location.state?.from?.pathname || "";
  return (
    <article className="w-full h-[100vh] grid place-items-center">
      <SVG image={notFound} />
      <span className="font-sans text-base text-wrap dark:text-gray-500 hover:text-gray-900 cursor-pointer">
        <Link to="/">Oops that path does not exist click me to go back</Link>
      </span>
    </article>
  );
};

export default NotFoundPage;
