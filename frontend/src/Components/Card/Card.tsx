import React from "react";
import { SearchResults } from "../../apitypes/musuem";
import privacy from "./privacy.svg";
import { Link } from "react-router-dom";
interface Props {
  cardInfo: SearchResults;
}

const Card = ({ cardInfo }: Props) => {
  return (
    <div className="rounded-md shadow-md p-3 w-full h-auto dark:bg-gray-900 grid">
      <img
        className="rounded-sm object-scale-down mb-2 place-self-center"
        width="300"
        height="400"
        src={
          typeof cardInfo.primaryImageUrl !== "string" ||
          cardInfo.primaryImageUrl === ""
            ? privacy
            : cardInfo.primaryImageUrl
        }
      />
      <Link to={`/obj/${cardInfo.objectId}`}>
        <h3 className="font-semibold text-wrap font-serif dark:text-gray-300 place-self-start">
          {cardInfo.title}
        </h3>
      </Link>

      <p className="text-wrap place-self-start"> {cardInfo.description}</p>
      <p className="place-self-start">{cardInfo.classification}</p>
      <p className="place-self-start">{cardInfo.technique}</p>
    </div>
  );
};

export default Card;
