import axios from "axios";
import { handleError } from "../Helpers/ErrorHandler";
import { AccountData } from "../AuthTypes";
const apiUrl = import.meta.env.VITE_API_URL_AUTH_ENDPOINT;

export const registerUserApi = async (username: string, password: string) => {
  try {
    const result = await axios.post<void>(`${apiUrl}register`, {
      username: username,
      password: password,
    });
    return result;
  } catch (err: any) {
    handleError(err);
  }
};

export const loginUserApi = async (username: string, password: string) => {
  try {
    const result = await axios.post<AccountData>(`${apiUrl}login`, {
      username: username,
      password: password,
    });
    return result;
  } catch (err: any) {
    handleError(err);
  }
};

export const refreshTokenApi = async (id: string) => {
  try {
    const result = await axios.post<AccountData>(
      `${apiUrl}refreshtoken`,
      {
        id: id,
      },
      {
        withCredentials: true,
      }
    );
    return result;
  } catch (err: any) {
    handleError(err);
  }
};
