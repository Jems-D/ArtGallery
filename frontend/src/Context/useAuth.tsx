import { createContext, useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import {
  loginUserApi,
  refreshTokenApi,
  registerUserApi,
} from "../Service/AuthService";
import React from "react";
import { AccountData } from "../AuthTypes";

interface UserContextType {
  user: AccountData | null;
  registerUser: (username: string, password: string) => void;
  loginUser: (username: string, password: string) => void;
  refreshToken: (id: string) => void;
  logoutUser: () => void;
  isAuthenticated: () => boolean;
}

interface Props {
  children: React.ReactNode;
}
//Fix the navigate
const UserContext = createContext<UserContextType>({} as UserContextType);

export const UserProvider = ({ children }: Props) => {
  const navigate = useNavigate();
  const [user, setUser] = useState<AccountData | null>(null);
  const [isReady, setIsReady] = useState<boolean>(false);

  useEffect(() => {
    const storedUser = localStorage.getItem("user");
    const isAuthenticated = localStorage.getItem("isAuthenticated");
    let userData;
    if (storedUser && isAuthenticated) {
      userData = JSON.parse(storedUser);
      setUser(userData);
    }

    if (userData) {
      refreshTokenApi(userData.id);
    }

    setIsReady(true);
  }, []);

  const registerUser = async (username: string, password: string) => {
    await registerUserApi(username, password)
      .then((res) => {
        if (res) {
          if (res.status === 200) console.log("Registration Success");
          navigate("/login");
        }
      })
      .catch((e) => console.log("Server Error", e));
  };

  const loginUser = async (username: string, password: string) => {
    await loginUserApi(username, password)
      .then((res) => {
        if (res) {
          localStorage.setItem("isAuthenticated", JSON.stringify(true));
          const UserData = {
            user: res?.data.user,
            role: res?.data.role,
            id: res?.data.id,
          };
          localStorage.setItem("user", JSON.stringify(UserData));
          setUser(UserData);
          navigate("/");
        }
      })
      .catch((e) => console.log("Server Error", e));
  };

  const refreshToken = async (id: string) => {
    await refreshTokenApi(id)
      .then((res) => {
        if (res) {
          const UserData = {
            user: res?.data.user,
            id: res?.data.id,
            role: res?.data.role,
          };
          setUser(UserData);
          localStorage.setItem("isAuthenticated", JSON.stringify(true));
          localStorage.setItem("user", JSON.stringify(UserData));
          navigate("/");
        }
      })
      .catch((e) => console.log("Server error", e));
  };

  const isAuthenticated = () => {
    return !!user; //negates into strict boolean meaning User does exist
  };

  const logoutUser = () => {
    setUser(null);
    localStorage.setItem("isAuthenticated", JSON.stringify(false));
    localStorage.removeItem("user");
    navigate("/");
  };

  return (
    <UserContext.Provider
      value={{
        loginUser,
        user,
        refreshToken,
        isAuthenticated,
        registerUser,
        logoutUser,
      }}
    >
      {isReady ? children : null}
    </UserContext.Provider>
  );
};

export const useAuth = () => React.useContext(UserContext);
