import axios from "axios";
import { handleError } from "../Helpers/ErrorHandler";
import {
  Exhibitions,
  ObjectMetadata,
  OtherWorks,
  Publications,
  Related,
  SearchResults,
} from "../apitypes/musuem";

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

export const getOtherWorksOfArtist = async (
  personId: number,
  objectId: number
) => {
  try {
    const otherWorks = await axios.get<OtherWorks[]>(
      `${museumUrl}/otherartworks?personId=${personId}&objectId=${objectId}`,
      {
        withCredentials: true,
      }
    );
    return otherWorks.data;
  } catch (err: any) {
    handleError(err);
  }
};

export const getExhibitions = async (objectId: number) => {
  try {
    const exhibitions = await axios.get<Exhibitions[]>(
      `${museumUrl}/exhibitions/${objectId}`,
      {
        withCredentials: true,
      }
    );
    return exhibitions.data;
  } catch (err: any) {
    handleError(err);
  }
};

export const getPubllications = async (objectId: number) => {
  try {
    const publications = await axios.get<Publications[]>(
      `${museumUrl}/publications/${objectId}`,
      {
        withCredentials: true,
      }
    );
    return publications.data;
  } catch (err: any) {
    handleError(err);
  }
};
