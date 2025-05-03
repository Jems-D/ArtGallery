import React from "react";
import { SearchResults } from "../../apitypes/musuem";
import privacy from "./privacy.svg";
interface Props {
  cardInfo: SearchResults;
}

const Card = ({ cardInfo }: Props) => {
  return (
    <div>
      <img
        src={
          typeof cardInfo.primaryImageUrl !== "string" ||
          cardInfo.primaryImageUrl === ""
            ? privacy
            : cardInfo.primaryImageUrl
        }
      />
      <p>{cardInfo.title}</p>
      <p>{cardInfo.description}</p>
      <p>{cardInfo.classification}</p>
      <p>{cardInfo.technique}</p>
    </div>
  );
};

export default Card;
