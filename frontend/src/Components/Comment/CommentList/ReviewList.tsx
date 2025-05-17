import React from "react";
import { Reviews } from "../../../apitypes/musuem";
import ReviewItem from "./ReviewItem";

interface Props {
  review: Reviews[];
}

const ReviewList = ({ review }: Props) => {
  return (
    <>
      <ul className="h-fit">
        <p className="font-serif text-2xl">Reviews</p>
        {review.map((rev, index) => {
          return (
            <li key={`rev-${index}`} className="border-b-1 border-gray-300">
              <ReviewItem review={rev} />
            </li>
          );
        })}
      </ul>
    </>
  );
};
export default ReviewList;
