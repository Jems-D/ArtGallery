import React, { MouseEventHandler } from "react";
import { getPageNumbers } from "../../../Helpers/PageFormatter";

interface Props {
  postPerPage: number;
  length: number;
  handlePagination: (e: number) => void;
  currentPage: number;
}

const Pagination = ({
  postPerPage,
  length,
  handlePagination,
  currentPage,
}: Props) => {
  const pageCount = Math.ceil(length / postPerPage);
  const paginationNumbers: (number | string)[] = getPageNumbers(
    pageCount,
    currentPage
  );

  // for (let i = 1; i <= pageCount; i++) {
  //   paginationNumbers.push(i);
  // }

  if (pageCount === 1) {
    return null;
  }

  return (
    <div className="h-[100px]">
      {paginationNumbers.map((pageNumber) => {
        return (
          <button
            className={`mr-1 outline-1 p-2 rounded-sm ${
              currentPage === pageNumber ? "bg-paledogwood" : ""
            } hover:outline-2`}
            onClick={() => {
              if (typeof pageNumber === "number") {
                handlePagination(pageNumber);
              }
            }}
            key={`num-${pageNumber}`}
          >
            {pageNumber}
          </button>
        );
      })}
    </div>
  );
};

export default Pagination;
