import { yupResolver } from "@hookform/resolvers/yup";
import React from "react";
import { useForm } from "react-hook-form";
import * as Yup from "yup";

interface Props {
  onSubmit: (e: CommentInputForm) => Promise<any>;
}
interface CommentInputForm {
  title: string;
  content: string;
  rating: number;
}

const validations = Yup.object().shape({
  title: Yup.string().required(),
  content: Yup.string().required(),
  rating: Yup.number().required(),
});

const CommentForm = ({ onSubmit }: Props) => {
  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm<CommentInputForm>({ resolver: yupResolver(validations) });
  const submit = async (e: CommentInputForm) => {
    onSubmit(e).then((res) => {
      reset();
    });
  };
  return (
    <form className="flex flex-col" onSubmit={handleSubmit(submit)}>
      <div className="">
        <label htmlFor="title">Title</label>
        <input
          id="title"
          placeholder="Title"
          type="text"
          {...register("title")}
        />
        {errors.title && <span>{errors.title.message}</span>}
      </div>
      <div>
        <label htmlFor="content">Content</label>
        <input
          id="content"
          placeholder="Content"
          type="text"
          {...register("content")}
        />
        {errors.content && <span>{errors.content.message}</span>}
      </div>
      <div>
        <label htmlFor="rating">Rating</label>
        <input
          id="rating"
          placeholder="Rating"
          type="number"
          {...register("rating")}
        />
        {errors.rating && <span>{errors.rating.message}</span>}
      </div>
      <button type="submit">Submit Review</button>
    </form>
  );
};

export default CommentForm;
