import { TrashIcon } from "@heroicons/react/24/outline";
import React, { SyntheticEvent } from "react";

interface Props {
  onCommentDelete: (e: SyntheticEvent) => void;
  value: number;
}

const CommentDeleteForm = ({ onCommentDelete, value }: Props) => {
  return (
    <form className="" onSubmit={onCommentDelete}>
      <input className="" hidden={true} readOnly={true} value={value} />
      <button type="submit" className="cursor-pointer">
        <TrashIcon className="size-3 opacity-50 hover:opacity-100 hover:text-red-600" />
      </button>
    </form>
  );
};

export default CommentDeleteForm;
