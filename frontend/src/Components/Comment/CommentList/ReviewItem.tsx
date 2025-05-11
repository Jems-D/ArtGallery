import React from "react";
import type { Reviews } from "../../../apitypes/musuem";

interface Props {
  review: Reviews;
}

const ReviewItem = ({ review }: Props) => {
  return (
    <>
      <p>{review.title}</p>
      <p>{review.content}</p>
      <p>{review.createdBy}</p>
    </>
  );
};

export default ReviewItem;
