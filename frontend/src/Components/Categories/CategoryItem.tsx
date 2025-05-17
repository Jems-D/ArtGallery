import React from "react";
import { Categories } from "../../apitypes/musuem";

interface Props {
  category: Categories;
}

const CategoryItem = ({ category }: Props) => {
  return (
    <div
      className={`rounded-md font-serif border-1 p-10 grid place-items-center`}
      style={{
        backgroundImage: `url(${category.image})`,
        backgroundSize: "contain",
        backgroundRepeat: "round",
      }}
    >
      <h3 className="text-9xl text-white">{category.title}</h3>
    </div>
  );
};

export default CategoryItem;
