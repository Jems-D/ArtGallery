import React from "react";

interface Props {
  image: string;
}

const SVG = ({ image }: Props) => {
  return <img src={image} height="300" width="300" />;
};

export default SVG;
