import React, { MouseEventHandler } from "react";

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
  const paginationNumbers = [];

  for (let i = 1; i <= pageCount; i++) {
    paginationNumbers.push(i);
  }
  return (
    <div className="h-[100px]">
      {paginationNumbers.map((pageNumber) => {
        return (
          <button
            className={`${currentPage === pageNumber ? "border-gray-900" : ""}`}
            onClick={() => handlePagination(pageNumber)}
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
