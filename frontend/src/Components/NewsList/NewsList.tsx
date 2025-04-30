import React, { JSX } from "react";
import { Root } from "../../news";
import News from "../News/News";

interface Props {
  data: Root;
}

const NewsList = ({ data }: Props): JSX.Element => {
  return (
    <ul className="list-none">
      {data.news.length ? (
        data.news.map((news) => {
          return (
            <li>
              <News data={news} />
            </li>
          );
        })
      ) : (
        <li>No news available</li>
      )}
    </ul>
  );
};

export default NewsList;
