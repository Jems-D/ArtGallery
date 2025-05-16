import React, { lazy, Suspense, useEffect, useState } from "react";
import Search from "../Components/Search/Search";
import { searchResult } from "../Service/MuseumService";
import { SearchResults } from "../apitypes/musuem";
import Skeleton from "react-loading-skeleton";
import CardList from "../Components/CardList/CardList";
import Pagination from "../Components/Comment/Pagination/Pagination";

type Props = {};

const SearchPage = (props: Props) => {
  const [query, setQuery] = useState<string>("");
  const [results, setResults] = useState<SearchResults[] | null>([]);
  const [totalCount, setTotalCount] = useState<number>(0);
  const [currentPage, setCurrentPage] = useState<number>(0);
  const [pageSize, setPageSize] = useState<number>(20);
  const [isLoading, setIsLoading] = useState<boolean>(false);

  const onChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    e.preventDefault();
    setQuery(e.target.value);
  };

  useEffect(() => {
    if (!query) return;
    fetchResults();
  }, [currentPage]);

  const onSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    if (!query) return;
    setIsLoading(true);
    setCurrentPage(1);
  };

  const fetchResults = async () => {
    const fetchResult = await searchResult(query, currentPage);
    console.log(fetchResult);
    if (fetchResult) {
      if (Array.isArray(fetchResult.artPieces)) {
        setResults(fetchResult.artPieces);
        setTotalCount(fetchResult.totaCount);
        setPageSize(fetchResult.pageSize);
        setIsLoading(false);
      }
    }
  };

  const handlePagination = (pageNumber: number) => {
    setCurrentPage(pageNumber);
  };

  return (
    <div className="grid place-items-center mt-10">
      <Search
        handleSubmit={onSubmit}
        search={query}
        handleInputChange={onChange}
      />
      <div className="mt-10 px-6 mb-10">
        {results?.length ? (
          <div className="flex flex-col">
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
        ) : null}
      </div>
    </div>
  );
};

export default SearchPage;
