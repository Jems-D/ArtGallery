import axios from "axios";
import { Root } from "react-dom/client";

type Props = {};

export const getLatestNews = async () => {
  try {
    const data = await axios.get<Root | null>(
      "https://api.currentsapi.services/v1/latest-news?category=art&limit=20&apiKey=IKoU0ELheQMztc9xxeH9DUDfT7hVoTkytkacjv1vrsFOUtjC"
    );
    return data.data;
  } catch (err) {
    if (axios.isAxiosError(err)) {
      console.log("Axios err", err.message);
    } else {
      console.log("Me problem", err);
    }
  }
};
