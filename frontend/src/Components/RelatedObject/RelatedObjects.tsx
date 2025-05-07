import React from "react";
import { Related } from "../../apitypes/musuem";
import { Link } from "react-router-dom";

interface Props {
  object: Related;
}

const RelatedObjects = ({ object }: Props) => {
  return (
    <Link to={`/obj/${object.objectId}`} reloadDocument type="">
      <p className="underline">{object.title}</p>
    </Link>
  );
};

export default RelatedObjects;
