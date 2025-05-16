import React, { useEffect, useState } from "react";

interface Props {
  totalStars?: number;
  initialRating: number;
  handleClick: (value: number) => void;
  isDisabled?: boolean;
}

function StarsRating({
  totalStars = 5,
  initialRating = 0,
  handleClick,
  isDisabled = false,
}: Props) {
  useEffect(() => {}, [initialRating]);

  return (
    <div
      className={`inline-block ${isDisabled === false ? "cursor-pointer" : ""}`}
    >
      {Array.from({ length: totalStars }, (_, i) => {
        const starValue = i + 1;
        const isFilled = starValue <= initialRating;
        return (
          <span
            key={starValue}
            onClick={() => {
              if (!isDisabled) {
                handleClick(starValue);
              }
            }}
            style={{
              fontSize: isDisabled === false ? "2rem" : "1rem",
              color: isFilled ? "#FFd700" : "#CCC",
              transition: "color 0.2s",
            }}
            role="button"
            aria-label={`${starValue} Star${starValue > 1 ? "s" : ""}`}
          >
            ★
          </span>
        );
      })}
    </div>
  );
}

export default StarsRating;
