import React from "react";
import { SearchResults } from "../../apitypes/musuem";
import Card from "../Card/Card";

interface Props {
  cardInfo: SearchResults[];
}

const CardList = ({ cardInfo }: Props) => {
  return (
    <ul className="list-none gap-5 columns-1 lg:columns-5">
      {cardInfo.map((info, index) => {
        return (
          <li key={index} className="mb-5 w-fit break-inside-avoid">
            <Card cardInfo={info} />
          </li>
        );
      })}
    </ul>
  );
};

export default CardList;
