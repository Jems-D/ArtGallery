import React, { useEffect, useState } from "react";
import MainBg from "../Components/Dashboard/MainBg";
import NewsList from "../Components/NewsList/NewsList";
import { Root } from "../news";
import { getLatestNews } from "../api/api";
import News from "../Components/News/News";

interface Props {}

const HomePage = ({}: Props) => {
  const [news, setNews] = useState<Root | any>(null);
  const [isLoading, setLoading] = useState<boolean>(false);
  useEffect(() => {
    fetchLatestNews();
  }, []);

  const fetchLatestNews = async () => {
    const result = await getLatestNews();
    if (typeof result === "string") {
      console.log("bruh");
    } else if (typeof result === "object") {
      setNews(result);
      setLoading(true);
    }
  };

  return (
    <aside className="flex flex-row flex-wrap mt-10 mx-6 lg:flex-nowrap lg:mx-6 lg:gap-x-6">
      <div className=" w-full h-[85vh] lg:flex-1">
        <MainBg />
      </div>
      <div className="flex flex-row w-full flex-nowrap max-h-[85vh] mt-5 lg:flex-1 lg:flex-wrap lg:overflow-y-scroll lg:mt-0 lg:mb-2">
        {isLoading && <NewsList data={news} />}
      </div>
    </aside>
  );
};

export default HomePage;
