import axios from "axios";
import { Root } from "react-dom/client";
const newsUrl = import.meta.env.VITE_API_URL_NEWS_ENDPOINT;
type Props = {};

export const getLatestNews = async () => {
  try {
    const data = await axios.get<Root | null>(`${newsUrl}`);
    return data.data;
  } catch (err) {
    if (axios.isAxiosError(err)) {
      console.log("Axios err", err.message);
    } else {
      console.log("Me problem", err);
    }
  }
};
