import React, { SyntheticEvent } from "react";
import { Favourites, SearchResults } from "../../apitypes/musuem";
import Card from "../Card/Card";

interface Props {
  cardInfo?: SearchResults[] | Favourites[];
  onPortfolioCreate: (e: SyntheticEvent) => void;
}

const CardList = ({ cardInfo, onPortfolioCreate }: Props) => {
  if (cardInfo === null || cardInfo === undefined) {
    return null;
  } else {
    return (
      <ul className="list-none gap-5 columns-1 md:columns-2 lg:columns-5">
        {cardInfo!.map((info, index) => {
          return (
            <li key={index} className="mb-5 w-fit break-inside-avoid">
              <Card cardInfo={info} onPortfolioCreate={onPortfolioCreate} />
            </li>
          );
        })}
      </ul>
    );
  }
};

export default CardList;
