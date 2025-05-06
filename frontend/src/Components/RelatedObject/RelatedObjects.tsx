import React from "react";
import { Related } from "../../apitypes/musuem";
import { Link } from "react-router-dom";

interface Props {
  object: Related;
}

const RelatedObjects = ({ object }: Props) => {
  return (
    <Link to={`/obj/${object.objectId}`} reloadDocument type="button">
      {object.title}
    </Link>
  );
};

export default RelatedObjects;
