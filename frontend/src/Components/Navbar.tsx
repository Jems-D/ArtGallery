import React from "react";
import {
  BookmarkIcon,
  MagnifyingGlassIcon,
  UserIcon,
} from "@heroicons/react/24/outline";
import { Bars3Icon } from "@heroicons/react/24/outline";

interface Props {}

const Navbar = (props: Props) => {
  return (
    <header className="flex flex-row w-full mt-2 shadow-white-50">
      <div className="flex flex-row items-center w-1/3 justify-start ml-6">
        <Bars3Icon className="w-8 h-8" />
        <p className="ml-2 text-sm font-serif">MENU</p>
      </div>
      <div className="flex flex-row items-center font-serif w-1/3 justify-center">
        <h1 className="font-serif text-2xl sm:text-2xl md:text-4xl">
          artgallery
        </h1>
      </div>
      <div className="flex flex-row items-center w-1/3 justify-end mr-6">
        <UserIcon className="w-8 h-8 mr-5" />
        <MagnifyingGlassIcon className="w-8 h-8" />
        <BookmarkIcon className="w-8 h-8 ml-5" />
      </div>
    </header>
  );
};

export default Navbar;
