import React from "react";
import { SearchResults } from "../../apitypes/musuem";
import Card from "../Card/Card";

interface Props {
  cardInfo: SearchResults[];
}

const CardList = ({ cardInfo }: Props) => {
  return (
    <ul className="list-none">
      {cardInfo.map((info, index) => {
        return (
          <li key={index}>
            <Card cardInfo={info} />
          </li>
        );
      })}
    </ul>
  );
};

export default CardList;
