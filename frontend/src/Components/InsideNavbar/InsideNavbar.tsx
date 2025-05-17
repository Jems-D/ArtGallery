import { Link } from "react-router-dom";
import Navbar from "../Navbar/Navbar";

interface Props {
  currentPage: string;
  handleClick: (e: string) => void;
}

const InsideNavBar = ({ handleClick, currentPage }: Props) => {
  const navbarLinks = ["publications", "exhibitions"];
  return (
    <nav className="flex justify-center">
      <div className="w-3/4 flex justify-between bg-timberwolf p-2 rounded-md px-5">
        {navbarLinks.map((link) => {
          return (
            <Link
              to={link}
              key={`links-${link}`}
              className={`uppercase ${
                currentPage === link ? "border-b-2" : ""
              }`}
              onClick={() => handleClick(link)}
            >
              {link}
            </Link>
          );
        })}
      </div>
    </nav>
  );
};

export default InsideNavBar;
