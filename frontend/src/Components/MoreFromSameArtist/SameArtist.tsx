import React from "react";
import { Link } from "react-router-dom";
import { OtherWorks } from "../../apitypes/musuem";

interface Props {
  otherWorks: OtherWorks;
}

const SameArtist = ({ otherWorks }: Props) => {
  return (
    <Link to={`/obj/${otherWorks.objectId}`}>
      <p className="person">{otherWorks.title}</p>
    </Link>
  );
};

export default SameArtist;
