import axios from "axios";

export const handleError = (error: Error) => {
  if (axios.isAxiosError(error)) {
    var err = error.response;
    if (Array.isArray(err?.data.errors)) {
      for (let val of err?.data.error) {
        console.log("Axios Error", val);
      }
    } else if (typeof err?.data.erros === "object") {
      for (let e in err?.data.errors) {
        console.log("Object type error", err?.data.errors[e][0]);
      }
    } else if (err?.data) {
      console.log("third error", err?.data);
    } else if (err) {
      console.log("fourth error", err?.data);
    }
  }
};
