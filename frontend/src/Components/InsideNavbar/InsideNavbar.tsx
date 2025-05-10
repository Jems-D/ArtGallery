import { Link } from "react-router-dom";
import Navbar from "../Navbar/Navbar";

const InsideNavBar = () => {
  return (
    <nav className="flex justify-center">
      <div className="w-3/4 flex justify-between bg-timberwolf p-2 rounded-md px-5">
        <Link to="publications" className="uppercase">
          Publications
        </Link>
        <Link to="exhibitions" className="uppercase">
          Exhibition
        </Link>
      </div>
    </nav>
  );
};

export default InsideNavBar;
