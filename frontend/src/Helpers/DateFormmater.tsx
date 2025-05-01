import React from "react";

export const DateFormmater = (date: string): string => {
  var months = [
    "January",
    "February",
    "March",
    "April",
    "May",
    "June",
    "July",
    "August",
    "September",
    "October",
    "November",
    "December",
  ];
  const year = date.substring(0, 4);
  const month = parseInt(date.substring(5, 7));
  const day = date.substring(8, 10);
  const newDate = `${day} ${months[month - 1]} ${year}`;
  return newDate;
};
