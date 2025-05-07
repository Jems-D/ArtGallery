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
