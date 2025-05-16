import React, { useEffect, useState } from "react";
import type { Reviews } from "../../apitypes/musuem";
import { createComment, getComments } from "../../Service/MuseumService";
import CommentForm from "./CommentForm/CommentForm";
import ReviewList from "./CommentList/ReviewList";
import Pagination from "./Pagination/Pagination";
interface Props {
  objectId: number;
}

interface CommentInputForm {
  title: string;
  content: string;
  rating: number;
}

function Review({ objectId }: Props) {
  const [comments, setComments] = useState<Reviews[]>([]);
  const [currentPage, setCurrentPage] = useState<number>(1);
  const [reviewPerPage, setReviewPerPage] = useState<number>(5);
  const [totalReviews, setTotalReviews] = useState<number>(0);
  useEffect(() => {
    fetchComments();
  }, [currentPage]);

  const onReviewSubmit = (e: CommentInputForm) => {
    return createComment(e.title, e.content, e.rating, objectId)
      .then((res) => {
        if (res?.status === 200) {
          fetchComments();
        }
      })
      .catch(() => {});
  };

  const fetchComments = async () => {
    const reviews = await getComments(objectId, currentPage);
    if (reviews) {
      if (Array.isArray(reviews.reviews)) {
        setComments(reviews.reviews);
        setReviewPerPage(reviews.pageSize);
        setTotalReviews(reviews.totalCount);
      }
    }
  };
  const handleClick = (pageNumber: number) => {
    setCurrentPage(pageNumber);
  };

  return (
    <div className="flex flex-col">
      <CommentForm onSubmit={onReviewSubmit} />
      <ReviewList review={comments} />
      <Pagination
        postPerPage={reviewPerPage}
        length={totalReviews}
        handlePagination={handleClick}
        currentPage={currentPage}
      />
    </div>
  );
}

export default Review;
