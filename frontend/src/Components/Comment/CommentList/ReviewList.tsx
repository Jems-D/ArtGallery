import React, { SyntheticEvent } from "react";
import { Reviews } from "../../../apitypes/musuem";
import ReviewItem from "./ReviewItem";
import { number } from "yup";

interface Props {
  review: Reviews[];
  onCommentDelete: (e: SyntheticEvent) => void;
}

const ReviewList = ({ review, onCommentDelete }: Props) => {
  return (
    <>
      <ul className="h-fit">
        <p className="font-serif text-2xl">Reviews</p>
        {review.map((rev, index) => {
          return (
            <li key={`rev-${index}`} className="border-b-1 border-gray-300">
              <ReviewItem review={rev} onCommentDelete={onCommentDelete} />
            </li>
          );
        })}
      </ul>
    </>
  );
};
export default ReviewList;
