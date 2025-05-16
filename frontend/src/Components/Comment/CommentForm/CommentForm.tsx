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
        <h3 className="font-serif text-3xl">Add a review</h3>
        <div className="flex flex-col">
          <input
            className="border-b-1 p-2 border-gray-400 focus:outline-0"
            id="title"
            placeholder="Title"
            type="text"
            {...register("title")}
          />
          {errors.title && (
            <span className="text-xs text-right opacity-50 text-red-500">
              {errors.title.message}
            </span>
          )}
        </div>
      </div>

      <div className="flex flex-col">
        <textarea
          className="border-b-1 p-2 border-gray-400 focus:outline-0"
          id="content"
          placeholder="Review"
          {...register("content")}
        />
        {errors.content && (
          <span className="text-xs text-right opacity-50 text-red-500">
            {errors.content.message}
          </span>
        )}
      </div>
      <div className="flex flex-col">
        <div className="">
          <label htmlFor="rating" className="mr-3 align-middle">
            Rating
          </label>
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
        {errors.rating && (
          <span className="text-xs text-right opacity-50 text-red-500">
            {errors.rating.message}
          </span>
        )}
      </div>
      <div className="grid place-items-end">
        <button
          type="submit"
          className="cursor-pointer border-1 w-1/4 p-2 rounded-sm"
        >
          Submit
        </button>
      </div>
    </form>
  );
};

export default CommentForm;
