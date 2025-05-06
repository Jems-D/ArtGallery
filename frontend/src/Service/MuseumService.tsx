import axios from "axios";
import { handleError } from "../Helpers/ErrorHandler";
import { ObjectMetadata, Related, SearchResults } from "../apitypes/musuem";

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

export const getObjectInformation = async (objectId: number) => {
  try {
    const objectInfo = await axios.get<ObjectMetadata>(
      `${museumUrl}/artpieceinfo/${objectId}`,
      {
        withCredentials: true,
      }
    );
    return objectInfo.data;
  } catch (err: any) {
    handleError(err);
  }
};

export const getRelatedObjects = async (objectId: number) => {
  try {
    const related = await axios.get<Related[]>(
      `${museumUrl}/related/${objectId}`,
      {
        withCredentials: true,
      }
    );
    return related.data;
  } catch (err: any) {
    handleError(err);
  }
};
