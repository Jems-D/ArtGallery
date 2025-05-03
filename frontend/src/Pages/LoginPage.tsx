import React from "react";
import * as Yup from "yup";
import { useAuth } from "../Context/useAuth";
import { yupResolver } from "@hookform/resolvers/yup";
import { useForm } from "react-hook-form";
import { Link, Navigate } from "react-router-dom";
type Props = {};

interface LoginForm {
  username: string;
  password: string;
}

const validation = Yup.object().shape({
  username: Yup.string().required("Username is required"),
  password: Yup.string().required("Password is required"),
});

const LoginPage = (props: Props) => {
  const { loginUser, isAuthenticated } = useAuth();
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<LoginForm>({ resolver: yupResolver(validation) });

  const onSubmit = (form: LoginForm) => {
    loginUser(form.username, form.password);
  };
  if (isAuthenticated()) {
    return <Navigate to="/" replace />;
  }

  return (
    <article className="w-full h-[100vh] grid place-items-center bg-applewhite">
      <form
        onSubmit={handleSubmit(onSubmit)}
        className="w-3/4 h-3/4 lg:h-1/2 lg:w-1/4"
      >
        <div className="flex flex-col">
          <div className="p-8">
            <div className="flex justify-center mb-10">
              <h2 className="text-3xl text-gray-900   font-serif tracking-tight dark:text-gray-100 ">
                Sign in to your account
              </h2>
            </div>
            <div className="flex mb-5">
              <div className="flex flex-col ">
                <label
                  className="tex  t-black text-sm/6 font-medium mb-2 dark:text-gray-100"
                  htmlFor="username"
                >
                  Username
                </label>
                <input
                  className="bg-white w-100 p-2  rounded-md outline-1 outline-offset-1 placeholder:text-gray-500"
                  id="username"
                  placeholder="artgalleryuser1"
                  {...register("username")}
                />
                {errors.username?.message && (
                  <span className="text-right mt-1 text-sm text-red-500">
                    {errors.username.message}
                  </span>
                )}
              </div>
            </div>
            <div className="flex mb-10">
              <div className="flex flex-col ">
                <label
                  className="text-black text-sm/6 font-medium mb-2 dark:text-gray-100"
                  htmlFor="password"
                >
                  Password
                </label>
                <input
                  className="bg-white w-100 p-2 rounded-md outline-1 outline-offset-1 "
                  id="password"
                  type="password"
                  {...register("password")}
                />
                {errors.password?.message && (
                  <span className="text-right mt-1 text-sm text-red-500">
                    {errors.password.message}
                  </span>
                )}
              </div>
            </div>
            <button
              className="bg-paledogwood rounded-md w-100 p-2 font-semibold"
              type="submit"
            >
              Sign In
            </button>
            <div className="mt-3 flex w-100 justify-items">
              <span className="text-base text-right w-full text-gray">
                No account yet?{" "}
                <Link to="/register" className="hover:text-blue-500">
                  Click here
                </Link>
              </span>
            </div>
          </div>
        </div>
      </form>
    </article>
  );
};
export default LoginPage;
