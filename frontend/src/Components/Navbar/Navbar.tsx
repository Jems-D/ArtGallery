import React from "react";
import {
  BookmarkIcon,
  MagnifyingGlassIcon,
  UserIcon,
} from "@heroicons/react/24/outline";
import { Bars3Icon } from "@heroicons/react/24/outline";
import { Link, useLocation } from "react-router-dom";
import { useAuth } from "../../Context/useAuth";

interface Props {}

const Navbar = (props: Props) => {
  const location = useLocation();

  const hideNavbar: string[] = ["/login", "/register"];

  if (hideNavbar.includes(location.pathname)) {
    return null;
  }

  return (
    <header className="flex flex-row w-full mt-2 shadow-white-5">
      <div className="flex flex-row items-center w-1/3 justify-start ml-6">
        <Bars3Icon className="w-6 h-6 lg:w-8 lg:h-8" />
        <p className="ml-2 text-sm font-serif dark:text-white">MENU</p>
      </div>
      <div className="flex flex-row items-center font-serif w-1/3 justify-center">
        <Link to="" className="font-serif text-2xl md:text-4xl dark:text-white">
          artgallery
        </Link>
      </div>
      <div className="flex flex-row items-center w-1/3 justify-end mr-6 ">
        <div className="group inline-block mr-5 cursor-pointer">
          <UserIcon className="w-6 h-6 mx-auto lg:w-8 lg:h-8 dark:text-white" />
          <span className="block h-1 bg-black dark:bg-white max-w-0 group-hover:max-w-full transition-all duration-500 ease-in-out"></span>
        </div>
        <Link to="search" className="group inline-block mr-5 cursor-pointer">
          <MagnifyingGlassIcon className="w-6 h-6 mx-auto  lg:w-8 sm:h-8 dark:text-white" />
          <span className="block h-1 bg-black dark:bg-white group-active:max-w-6 group-focus:max-w-6 max-w-0 mx-auto group-hover:max-w-6 transition-all duration-500 ease-in-out"></span>
        </Link>
        <Link to="favs" className="group inline-block cursor-pointer">
          <BookmarkIcon className="w-6 h-6 mx-auto  lg:w-8 lg:h-8 dark:text-white" />
          <span className="block h-1 bg-black dark:bg-white max-w-0 mx-auto group-active:max-w-6 group-focus:max-w-6 group-hover:max-w-6 transition-all duration-500 ease-in-out"></span>
        </Link>
      </div>
    </header>
  );
};

export default Navbar;
