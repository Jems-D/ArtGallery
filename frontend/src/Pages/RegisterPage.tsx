import React from "react";
import { useAuth } from "../Context/useAuth";
import * as Yup from "yup";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
type Props = {};

const RegisterPage = (props: Props) => {
  const { registerUser } = useAuth();

  interface RegisterForm {
    username: string;
    password: string;
  }

  const validation = Yup.object().shape({
    username: Yup.string().required("Username is required"),
    password: Yup.string().required("Password is required"),
  });

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<RegisterForm>({ resolver: yupResolver(validation) });

  const onSubmit = (form: RegisterForm) => {
    registerUser(form.username, form.password);
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <div className="flex flex-col items-center">
        <div className="">
          <label
            className="text-sm text-start dark:text-white"
            htmlFor="userName"
          >
            Username
          </label>
          <input
            type="string"
            className=""
            id="userName"
            {...register("username")}
          />
          {errors.username?.message && <span>{errors.username.message}</span>}
        </div>
        <div className="">
          <label
            className="text-sm text-start dark:text-white"
            htmlFor="passWord"
          >
            Password
          </label>
          <input
            type="password"
            className=""
            id="passWord"
            {...register("password")}
          />
          {errors.password?.message && <span>{errors.password.message}</span>}
        </div>
      </div>
      <button className="" type="submit">
        Sign Up
      </button>
    </form>
  );
};

export default RegisterPage;
