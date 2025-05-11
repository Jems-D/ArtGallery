import React, { useEffect, useState } from "react";
import type { Reviews } from "../../apitypes/musuem";
import { createComment, getComments } from "../../Service/MuseumService";
import CommentForm from "./CommentForm/CommentForm";
import ReviewList from "./CommentList/ReviewList";
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

  useEffect(() => {
    fetchComments();
  }, []);

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
    const reviews = await getComments(objectId);
    if (Array.isArray(reviews)) {
      setComments(reviews);
    }
  };

  return (
    <div className="flex flex-col">
      <CommentForm onSubmit={onReviewSubmit} />
      <ReviewList review={comments} />
    </div>
  );
}

export default Review;
