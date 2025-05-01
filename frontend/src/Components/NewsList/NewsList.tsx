import React, { JSX } from "react";
import { Root } from "../../news";
import News from "../News/News";

interface Props {
  data: Root;
}

const NewsList = ({ data }: Props): JSX.Element => {
  return (
    <ul className="list-none columns:1 gap-4 lg:columns-2">
      {data.news.length ? (
        data.news.map((news) => {
          return (
            <li className="w-full break-inside-avoid mb-4">
              <News data={news} />
            </li>
          );
        })
      ) : (
        <li className="font-sans dark:white">No news available</li>
      )}
    </ul>
  );
};

export default NewsList;
