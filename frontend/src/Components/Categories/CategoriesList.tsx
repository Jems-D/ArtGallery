import React from "react";
import { Categories } from "../../apitypes/musuem";
import CategoryItem from "./CategoryItem";
interface Props {
  categories: Categories[];
}

function CategoriesList({ categories }: Props) {
  return (
    <ul className="list-none">
      {categories.map((cat, index) => {
        return (
          <li className="mb-2" key={`${cat.title}-${index}`}>
            <CategoryItem category={cat} />
          </li>
        );
      })}
    </ul>
  );
}

export default CategoriesList;
