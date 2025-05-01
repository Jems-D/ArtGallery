import React from "react";
import { News as NewsType } from "../../news";
import "./News.css";
import { Navigate } from "react-router-dom";
import { DateFormmater } from "../../Helpers/DateFormmater";

interface Props {
  data: NewsType;
}

const News = ({ data }: Props) => {
  return (
    <div className="flex flex-col shadow" id="parent">
      <img
        className="h-auto w-full mb-3"
        id="image"
        src={data.image}
        alt={data.description}
      />
      <div className="px-2 pb-1">
        <p className="font-serif text-lg capitalize mb-2 text-wrap dark:text-gray-100">
          {data.title}
        </p>
        <p className="font-sans  text-shadow text-sm uppercase text-wrap dark:text-gray-200">
          {DateFormmater(data.published)}
        </p>
        <div className="flex justify-end">
          <a href={data.url} target="_blank" className="">
            <span className="text-right text-timberwolf text-[8px] hover:text-black">
              Read more
            </span>
          </a>
        </div>
      </div>
    </div>
  );
};

export default News;
