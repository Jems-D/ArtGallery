import React, { useEffect, useState } from "react";

interface Props {
  totalStars?: number;
  initialRating: number;
  handleClick: (value: number) => void;
}

function StarsRating({
  totalStars = 5,
  initialRating = 0,
  handleClick,
}: Props) {
  const [hovered, setHovered] = useState<number>(0);

  useEffect(() => {
    setHovered(0);
  }, [initialRating]);

  const handleMouseEnter = (value: number) => setHovered(value);
  const handleMouseLeave = () => setHovered(0);

  return (
    <div className="inline-block cursor-pointer">
      {Array.from({ length: totalStars }, (_, i) => {
        const starValue = i + 1;
        const isFilled = starValue <= (hovered || initialRating);
        return (
          <span
            key={starValue}
            onClick={() => handleClick(starValue)}
            onMouseEnter={() => handleMouseEnter(starValue)}
            onMouseLeave={() => handleMouseLeave}
            style={{
              fontSize: "2rem",
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
