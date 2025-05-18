import React from "react";
import { Categories, CategorySearch } from "../../apitypes/musuem";
import { Link } from "react-router-dom";
import { CategoryImage } from "../../Helpers/CategoryImage";

interface Props {
  category: Categories | CategorySearch;
  property?: string;
}

const CategoryItem = ({ category, property = "century" }: Props) => {
  property = CategoryImage(property);
  const catgory = property.substring(34, property.indexOf("."));
  if ("title" in category) {
    return (
      <div
        className={`rounded-md font-serif border-1 p-10 grid place-items-center`}
        style={{
          backgroundImage: `url(${category.image})`,
          backgroundSize: "cover",
          backgroundRepeat: "no-repeat",
        }}
      >
        <Link to={`/categories/${category.title}`}>
          <h3 className="text-3xl text-white lg:text-9xl">{category.title}</h3>
        </Link>
      </div>
    );
  }

  return (
    <div
      className={`rounded-md font-serif border-1 p-10 grid place-items-center`}
    >
      <Link to={`/categories/${catgory}/${category.id}`}>
        <h3
          className={`text-3xl lg:text-9xl text-wrap text-center`}
          id="text"
          style={{
            backgroundImage: `url(${property})`,
            backgroundSize: "cover",
            backgroundPosition: "center",
            WebkitBackgroundClip: "text",
            backgroundClip: "text",
            WebkitTextFillColor: "transparent",
          }}
        >
          {category.name}
        </h3>
      </Link>
    </div>
  );
};

export default CategoryItem;
