import React, { SyntheticEvent } from "react";

interface Props {
  onSubmitFav?: (e: SyntheticEvent) => void;
  objectId: number;
}

const FavForm = ({ onSubmitFav, objectId }: Props) => {
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
};

export default FavForm;
