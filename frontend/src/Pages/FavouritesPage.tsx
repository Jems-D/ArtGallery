import React, { useEffect, useState } from "react";
import { getAllFavourites, removeFromFav } from "../Service/MuseumService";
import { Favourites } from "../apitypes/musuem";
import CardArtworks from "../Components/CardList/CardArtworks";
import CardList from "../Components/CardList/CardList";
import { toast } from "react-toastify";

type Props = {};

const FavouritesPage = (props: Props) => {
  const [objectId, setObjectId] = useState<number>(0);
  const [favourites, setFavs] = useState<Favourites[] | null>([]);
  const [onDelete, setDelete] = useState<boolean>(false);
  useEffect(() => {
    fetchFavs();
  }, [onDelete]);
  const fetchFavs = async () => {
    const favs = await getAllFavourites();
    if (favs) {
      setFavs(favs.data);
    }
  };

  const onFavDelete = (e: any) => {
    e.preventDefault();
    removeFromFav(e.target[0].value).then((res) => {
      if (res?.status === 204) {
        setDelete(true);
        toast.success("Deleted");
      }
    });
  };

  return (
    <>
      {favourites?.length && (
        <div className="mx-6 mt-10">
          <CardList cardInfo={favourites} onFavDelete={onFavDelete} />
        </div>
      )}
    </>
  );
};

export default FavouritesPage;
