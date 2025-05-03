import axios from "axios";
import { handleError } from "../Helpers/ErrorHandler";
import { SearchResults } from "../apitypes/musuem";

const museumUrl = import.meta.env.VITE_API_URL_MUSUEM_ENDPOINT;

export const searchResult = async (keyword: string, pageNumber: number) => {
  try {
    var searchResults = await axios.get<SearchResults[]>(
      `${museumUrl}?pageNumber=${pageNumber}&keyword=${keyword}`,
      {
        withCredentials: true,
      }
    );
    return searchResults.data;
  } catch (err: any) {
    handleError(err);
  }
};
