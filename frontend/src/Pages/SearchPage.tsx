import React, { lazy, Suspense, useEffect, useState } from "react";
import Search from "../Components/Search/Search";
import { searchResult } from "../Service/MuseumService";
import { SearchResults } from "../apitypes/musuem";
import Skeleton from "react-loading-skeleton";
import CardList from "../Components/CardList/CardList";

type Props = {};

const SearchPage = (props: Props) => {
  const [query, setQuery] = useState<string>("");
  const [results, setResults] = useState<SearchResults[] | null>([]);
  const [isLoading, setIsLoading] = useState<boolean>(false);

  const onChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    e.preventDefault();
    setQuery(e.target.value);
  };

  const onSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    setIsLoading(true);
    const fetchResult = await searchResult(query, 1);
    console.log(fetchResult);
    if (Array.isArray(fetchResult)) {
      setResults(fetchResult);
      setIsLoading(false);
    }
  };

  return (
    <div className="grid place-items-center mt-10">
      <Search
        handleSubmit={onSubmit}
        search={query}
        handleInputChange={onChange}
      />
      <div className="mt-10 px-6 mb-10">
        {results?.length ? <CardList cardInfo={results} /> : null}
      </div>
    </div>
  );
};

export default SearchPage;
