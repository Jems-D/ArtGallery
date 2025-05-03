import React, { useEffect, useState } from "react";
import Search from "../Components/Search/Search";
import { useSearchParams } from "react-router-dom";
import { searchResult } from "../Service/MuseumService";
import { SearchResults } from "../apitypes/musuem";
import CardList from "../Components/CardList.tsx/CardList";

type Props = {};

const SearchPage = (props: Props) => {
  const [query, setQuery] = useState<string>("");
  const [results, setResults] = useState<SearchResults[] | null>();

  const onChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    e.preventDefault();
    setQuery(e.target.value);
  };

  const onSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const fetchResult = await searchResult(query, 1);
    console.log(fetchResult);
    setResults(fetchResult);
  };

  return (
    <div className="grid place-items-center mt-10">
      <Search
        handleSubmit={onSubmit}
        search={query}
        handleInputChange={onChange}
      />
      <div className="mt-10">{results && <CardList cardInfo={results} />}</div>
    </div>
  );
};

export default SearchPage;
