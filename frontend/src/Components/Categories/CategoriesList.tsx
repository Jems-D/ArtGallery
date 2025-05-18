import React, { useState } from "react";
import { Categories, CategorySearch } from "../../apitypes/musuem";
import CategoryItem from "./CategoryItem";
import century from "../Categories/Images/century.jpg";
import classification from "../Categories/Images/classification.jpg";

interface Props {
  categories: Categories[] | CategorySearch[];
  propName?: string;
}

function CategoriesList({ categories, propName }: Props) {
  return (
    <ul className="list-none">
      {categories.map((cat, index) => {
        return (
          <li className="mb-2" key={`cat-${index}`}>
            <CategoryItem category={cat} property={propName} />
          </li>
        );
      })}
    </ul>
  );
}

export default CategoriesList;
