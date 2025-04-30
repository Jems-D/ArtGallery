import React from "react";
import { News as NewsType } from "../../news";

interface Props {
  data: NewsType;
}

const News = ({ data }: Props) => {
  return (
    <div className="flex flex-col">
      <img className="object-fit mb-3" src={data.image} />
      <p className="font-serif text-lg capitalize mb-2">{data.title}</p>
      <p className="font-sans text-sm uppercase">{data.published}</p>
    </div>
  );
};

export default News;
