import React, { useEffect, useState } from "react";
import { getAllFavourites } from "../Service/MuseumService";
import { Favourites } from "../apitypes/musuem";
import CardArtworks from "../Components/CardList/CardArtworks";
import CardList from "../Components/CardList/CardList";

type Props = {};

const FavouritesPage = (props: Props) => {
  const [favourites, setFavs] = useState<Favourites[] | null>([]);
  useEffect(() => {
    fetchFavs();
  }, []);
  const fetchFavs = async () => {
    const favs = await getAllFavourites();
    if (favs) {
      setFavs(favs.data);
    }
  };

  return (
    <>
      {favourites?.length && (
        <div className="mx-6 mt-10">
          <CardList cardInfo={favourites} />
        </div>
      )}
    </>
  );
};

export default FavouritesPage;
