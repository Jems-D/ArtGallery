import React, { SyntheticEvent } from "react";

interface Props {
  onSubmitFav?: (e: SyntheticEvent) => void;
  objectId: number;
  onFavDelete?: (e: SyntheticEvent) => void;
  isFav?: boolean;
}

const FavForm = ({
  onSubmitFav,
  objectId,
  onFavDelete,
  isFav = true,
}: Props) => {
  if (isFav) {
    return (
      <form onSubmit={onSubmitFav}>
        <input type="number" hidden={true} readOnly={true} value={objectId} />
        <button
          type="submit"
          className="border-1 rounded-sm bg-paledogwood text-black p-2 cursor-pointer"
        >
          Favourite
        </button>
      </form>
    );
  } else {
    return (
      <form onSubmit={onFavDelete}>
        <input type="number" hidden={true} readOnly={true} value={objectId} />
        <button
          type="submit"
          className="border-1 rounded-sm bg-red-700 text-black p-2 cursor-pointer"
        >
          Delete
        </button>
      </form>
    );
  }
};

export default FavForm;
