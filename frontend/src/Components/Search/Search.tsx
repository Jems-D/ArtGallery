import React from "react";

interface Props {
  handleSubmit: (e: React.FormEvent<HTMLFormElement>) => void;
  search: string;
  handleInputChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
}

const Search = ({ handleSubmit, search, handleInputChange }: Props) => {
  return (
    <form onSubmit={handleSubmit} className="w-3/4 lg:w-1/2">
      <div className="p-0 m-0 outline-1 rounded-md -outline-offset-1 outline-gray-300 flex flex-row">
        <input
          className="rounded-s-md bg-white p-2 w-[90%] placeholder:text-gray-500 focus:outline-none"
          placeholder="Look up artworks"
          value={search}
          onChange={handleInputChange}
        />
        <button
          className="rounded-e-md p-2 w-[10%] bg-paledogwood cursor-pointer"
          type="submit"
        >
          Search
        </button>
      </div>
    </form>
  );
};

export default Search;
