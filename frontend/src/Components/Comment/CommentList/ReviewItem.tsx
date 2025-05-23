import React, { SyntheticEvent } from "react";
import type { Reviews } from "../../../apitypes/musuem";
import StarsRating from "../CommentForm/StarsRating";
import { UserCircleIcon } from "@heroicons/react/16/solid";
import { useAuth } from "../../../Context/useAuth";
import { TrashIcon } from "@heroicons/react/24/outline";
import CommentDeleteForm from "../CommentDeleteForm/CommentDeleteForm";

interface Props {
  review: Reviews;
  onCommentDelete: (e: SyntheticEvent) => void;
}

const ReviewItem = ({ review, onCommentDelete }: Props) => {
  const { user } = useAuth();
  const username = user?.user;

  return (
    <>
      <div className="flex">
        <UserCircleIcon className="size-5 text-gray-500" />
        <div className="flex flex-col ml-2">
          <div className="flex">
            <p className="text-sm opacity-80 mr-2">
              Review by:{" "}
              <span className="font-semibold text-sm">{review.createdBy}</span>
            </p>
            <StarsRating
              initialRating={review.rating}
              handleClick={function (value: number): void {
                throw new Error("Function not implemented.");
              }}
              isDisabled={true}
            />
            <div className="ml-2">
              {username === user?.user ? (
                <CommentDeleteForm
                  onCommentDelete={onCommentDelete}
                  value={review.id}
                />
              ) : null}
            </div>
          </div>

          <span className="text-sm opacity-90 font-serif">{review.title}</span>
          <p className="text-sm opacity-80">{review.content}</p>
        </div>
      </div>
    </>
  );
};

export default ReviewItem;
