export interface SearchResults {
  imagepermissionlevel: number;
  technique: string | null;
  description: any | null;
  id: number;
  classification: string | null;
  title: string | null;
  primaryImageUrl: string | null;
  objectId: number;
}

export interface SearchResultsPagination {
  totaCount: number;
  pageSize: number;
  pageNumber: number;
  result: SearchResults[];
}

//For object info
export interface ObjectMetadata {
  technique: string | null;
  description: string | null;
  medium: string | null;
  classification: string | null;
  title: string | null;
  primaryImageUrl: string | null;
  people: People[];
  url: string | null;
  imagePermissionLevel: number;
  dated: string | null;
  id: number;
  objectId: number;
  dimensions: string | null;
  provenance: string | null;
  culture: string | null;
}

export interface People {
  role: string | null;
  birthplace: string | null;
  gender: string | null;
  displayDate: string | null;
  prefix: string | null;
  culture: string | null;
  displayName: string | null;
  alphaSort: string | null;
  name: string | null;
  personId: number;
  deathPlace: string | null;
  displayOrder: number;
}

//related

export interface Related {
  title: string | null;
  objectId: number;
}

//artist other works

export interface OtherWorks {
  title: string | null;
  objectId: number;
}

//exhibitions
export interface Exhibitions {
  begindate: string | null;
  enddate: string | null;
  exhibitionId: number;
  citation: string | null;
  title: string | null;
}

export interface Publications {
  publicationPlace: string | null;
  publicationYear: number;
  citation: string | null;
  pageNumbers: string | null;
  format: string | null;
  title: string | null;
}
//Reviews

export interface Reviews {
  title: string;
  content: string;
  rating: number;
  createdAt: string;
  createdBy: string;
  artPieceId: number;
  id: number;
}

export interface ReviewsPagination {
  totalCount: number;
  pageSize: number;
  pageNumber: number;
  reviews: Reviews[];
}

export interface Categories {
  title: string;
  image?: string;
  id?: number;
}

export interface CategorySearch {
  name: string | null;
  id: number;
}

export interface CategoriesSearchResult {
  totaCount: number;
  pageSize: number;
  pageNumber: number;
  type: string;
  result: CategorySearch[];
}

export interface Favourites {
  title: string | null;
  imageUrl: string | null;
  addedAt: string | null;
  objectId: number;
}
