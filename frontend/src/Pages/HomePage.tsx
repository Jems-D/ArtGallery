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
    <aside className="flex flex-row flex-wrap mt-10 ml-6 mr-6 lg:flex-nowrap lg:mr-0">
      <div className=" w-full h-[85vh] lg:w-1/2">
        <MainBg />
      </div>
      <div className="w-full lg:w-1/2 mr-6 ml-6">
        {isLoading && <NewsList data={news} />}
      </div>
    </aside>
  );
};

export default HomePage;
