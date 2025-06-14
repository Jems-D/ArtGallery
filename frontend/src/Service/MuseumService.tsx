import axios from "axios";
import { handleError } from "../Helpers/ErrorHandler";
import {
  CategoriesSearchResult,
  Exhibitions,
  Favourites,
  ObjectMetadata,
  OtherWorks,
  Publications,
  Related,
  Reviews,
  ReviewsPagination,
  SearchResults,
  SearchResultsPagination,
} from "../apitypes/musuem";

const museumUrl = import.meta.env.VITE_API_URL_MUSUEM_ENDPOINT;
const reviewUrl = import.meta.env.VITE_API_URL_MUSUEM_REVIEW_ENDPOINT;
const favUrl = import.meta.env.VITE_API_URL_MUSUEM_FAVORITE_ENDPOINT;

export const searchResult = async (keyword: string, pageNumber: number) => {
  try {
    var searchResults = await axios.get<SearchResultsPagination>(
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

export const createComment = async (
  title: string,
  content: string,
  rating: number,
  objectId: number
) => {
  try {
    const createdComment = await axios.post<Reviews>(
      `${reviewUrl}/${objectId}`,
      {
        title: title,
        content: content,
        rating: rating,
      },
      {
        withCredentials: true,
      }
    );
    return createdComment;
  } catch (err: any) {
    handleError(err);
  }
};

export const getComments = async (objectId: number, pageNumber: number) => {
  try {
    const reviews = await axios.get<ReviewsPagination>(
      `${reviewUrl}?ObjectId=${objectId}&PageNumber=${pageNumber}`,
      {
        withCredentials: true,
      }
    );
    return reviews;
  } catch (err: any) {
    handleError(err);
  }
};

export const deleteComment = async (id: number) => {
  try {
    const deleted = await axios.delete(`${reviewUrl}/${id}`, {
      withCredentials: true,
    });
    return deleted;
  } catch (err: any) {
    handleError(err);
  }
};

export const getCategories = async (pageNumber: number, property: string) => {
  try {
    const categories = await axios.get<CategoriesSearchResult>(
      `${museumUrl}/category?pageNumber=${pageNumber}&property=${property}`,
      {
        withCredentials: true,
      }
    );
    return categories;
  } catch (err: any) {
    handleError(err);
  }
};

export const getArtworksBasedOnCategory = async (
  id: number,
  pageNumber: number,
  property: string
) => {
  try {
    const artworks = await axios.get<SearchResultsPagination>(
      `${museumUrl}/category/artpieces?Id=${id}&pageNumber=${pageNumber}&property=${property}`,
      {
        withCredentials: true,
      }
    );
    return artworks;
  } catch (err: any) {
    handleError(err);
  }
};

export const addToFavorites = async (objectId: number) => {
  try {
    const addFavs = await axios.post<void>(`${favUrl}/${objectId}`, null, {
      withCredentials: true,
    });
    return addFavs;
  } catch (err: any) {
    handleError(err);
  }
};

export const getAllFavourites = async () => {
  try {
    const favs = await axios.get<Favourites[]>(`${favUrl}`, {
      withCredentials: true,
    });

    return favs;
  } catch (err: any) {
    handleError(err);
  }
};

export const removeFromFav = async (objectId: number) => {
  try {
    const removedFromFav = await axios.delete<void>(`${favUrl}/${objectId}`, {
      withCredentials: true,
    });

    return removedFromFav;
  } catch (err: any) {
    handleError(err);
  }
};



