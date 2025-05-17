import React, { lazy, Suspense, useEffect, useState } from "react";
import Search from "../Components/Search/Search";
import { searchResult } from "../Service/MuseumService";
import { Categories, SearchResults } from "../apitypes/musuem";
import Skeleton from "react-loading-skeleton";
import CardList from "../Components/CardList/CardList";
import Pagination from "../Components/Comment/Pagination/Pagination";
import CategoriesList from "../Components/Categories/CategoriesList";
import culture from "../Components/Categories/Images/culture.jpg";
import century from "../Components/Categories/Images/century.jpg";
import classification from "../Components/Categories/Images/classification.jpg";
import medium from "../Components/Categories/Images/medium.jpg";
import period from "../Components/Categories/Images/period.jpg";
import person from "../Components/Categories/Images/person.jpg";
import place from "../Components/Categories/Images/place.jpg";
import technique from "../Components/Categories/Images/technique.jpg";

type Props = {};

const SearchPage = (props: Props) => {
  const [query, setQuery] = useState<string>("");
  const [results, setResults] = useState<SearchResults[] | null>([]);
  const [totalCount, setTotalCount] = useState<number>(0);
  const [currentPage, setCurrentPage] = useState<number>(1);
  const [refreshKey, setRefreshKey] = useState<number>(0);
  const [pageSize, setPageSize] = useState<number>(20);
  const [isLoading, setIsLoading] = useState<boolean>(false);

  const onChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    e.preventDefault();
    setQuery(e.target.value);
  };

  useEffect(() => {
    if (!query) return;
    fetchResults();
  }, [currentPage, refreshKey]);

  const onSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    if (query === "") return;
    setIsLoading(true);
    setCurrentPage(1);
    setRefreshKey(() => refreshKey + 1);
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

  const categories: Categories[] = [
    {
      title: "Century",
      image: century,
    },
    {
      title: "Classification",
      image: classification,
    },
    {
      title: "Culture",
      image: culture,
    },
    {
      title: "Medium",
      image: medium,
    },
    {
      title: "Period",
      image: period,
    },
    {
      title: "Person",
      image: person,
    },
    {
      title: "Place",
      image: place,
    },
    {
      title: "Technique",
      image: technique,
    },
  ];

  return (
    <div className="grid place-items-center mt-10">
      <Search
        handleSubmit={onSubmit}
        search={query}
        handleInputChange={onChange}
      />
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
    </div>
  );
};

export default SearchPage;
