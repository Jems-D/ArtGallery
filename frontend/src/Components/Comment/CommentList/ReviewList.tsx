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
        {review.map((rev, index) => {
          return (
            <li key={`rev-${index}`}>
              <ReviewItem review={rev} />
            </li>
          );
        })}
      </ul>
    </>
  );
};
export default ReviewList;
