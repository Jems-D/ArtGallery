import React from "react";
import Search from "./Search";
import CardList from "../CardList/CardList";
import Pagination from "../Comment/Pagination/Pagination";
import CategoriesList from "../Categories/CategoriesList";
import { Categories, SearchResults } from "../../apitypes/musuem";

interface Props {}

const SearchCat = ({}: Props) => {
  return (
    <>
      <div className="mt-10 px-6 mb-10 w-[100vw]">
        {results?.length ? (
          <div className="flex flex-col gap-2">
            <CardList cardInfo={results} />
            <div className="grid place-items-end">
              <Pagination
                postPerPage={pageSize}
                length={totalCount}
                handlePagination={handlePagination}
                currentPage={currentPage}
              />
            </div>
          </div>
        ) : (
          <div className="flex flex-col">
            <div>
              <h1 className="text-2xl font-serif">Browse All</h1>
              <CategoriesList categories={categories} />
            </div>
          </div>
        )}
      </div>
    </>
  );
};

export default SearchCat;
