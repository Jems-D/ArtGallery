import React, { Suspense, SyntheticEvent } from "react";
import { Favourites, SearchResults } from "../../apitypes/musuem";
import privacy from "./privacy.svg";
import { Link } from "react-router-dom";
import FavForm from "../FavForm/FavForm";
import { DateFormmater } from "../../Helpers/DateFormmater";
import { removeFromFav } from "../../Service/MuseumService";
import { toast } from "react-toastify";
interface Props {
  cardInfo: SearchResults | Favourites;
  onPortfolioCreate?: (e: SyntheticEvent) => void;
  onFavDelete?: (e: SyntheticEvent) => void;
  objectId?: number;
}
const Card = ({
  cardInfo,
  onPortfolioCreate,
  onFavDelete,
  objectId,
}: Props) => {
  if ("addedAt" in cardInfo) {
    const date = cardInfo.addedAt?.substring(0, 10);

    return (
      <div className="rounded-md shadow-md p-3 w-full h-auto dark:bg-gray-900 grid">
        <img
          className="rounded-sm object-scale-down mb-2 place-self-center"
          width="300"
          height="400"
          src={
            typeof cardInfo.imageUrl !== "string" || cardInfo.imageUrl === ""
              ? privacy
              : cardInfo.imageUrl
          }
        />
        <h3 className="font-semibold text-wrap font-serif dark:text-gray-300 place-self-start">
          {cardInfo.title}
        </h3>
        {date && (
          <p className="text-wrap place-self-start">{DateFormmater(date)}</p>
        )}
        <div className="grid place-items-end">
          {cardInfo.objectId && (
            <FavForm
              objectId={cardInfo.objectId}
              onFavDelete={onFavDelete}
              isFav={false}
            />
          )}
        </div>
      </div>
    );
  }

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
      <div className="grid place-items-end">
        <FavForm onSubmitFav={onPortfolioCreate} objectId={cardInfo.objectId} />
      </div>
    </div>
  );
};

export default Card;
