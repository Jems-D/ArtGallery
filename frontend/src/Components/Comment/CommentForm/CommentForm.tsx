import { StarIcon } from "@heroicons/react/24/outline";
import { yupResolver } from "@hookform/resolvers/yup";
import React from "react";
import { Controller, useForm } from "react-hook-form";
import * as Yup from "yup";
import StarsRating from "./StarsRating";
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
  rating: Yup.number()
    .required()
    .min(1, "Atleast one star")
    .max(5, "Five is the highest"),
});

const CommentForm = ({ onSubmit }: Props) => {
  const {
    register,
    handleSubmit,
    reset,
    control,
    formState: { errors },
  } = useForm<CommentInputForm>({ resolver: yupResolver(validations) });
  const submit = async (e: CommentInputForm) => {
    onSubmit(e).then((res) => {
      reset({ rating: 0 });
    });
  };

  return (
    <form className="flex flex-col" onSubmit={handleSubmit(submit)}>
      <div className="">
        <h3 className="font-serif">Add a review</h3>
        <input
          className="border-b-1 p-2 focus:outline-0"
          id="title"
          placeholder="Title"
          type="text"
          {...register("title")}
        />
        {errors.title && <span>{errors.title.message}</span>}
      </div>
      <div>
        <textarea
          className="border-b-1 p-2 w-100 focus:outline-0"
          id="content"
          placeholder="Review"
          {...register("content")}
        />
        {errors.content && <span>{errors.content.message}</span>}
      </div>
      <div>
        <label htmlFor="rating">Rating</label>
        <Controller
          name="rating"
          control={control}
          render={({ field }) => (
            <StarsRating
              initialRating={field.value}
              handleClick={field.onChange}
            />
          )}
        />
      </div>
      <button type="submit" className="cursor-pointer">
        Submit Review
      </button>
    </form>
  );
};

export default CommentForm;
