import React from "react";
import { Related } from "../../apitypes/musuem";
import RelatedObjects from "./RelatedObjects";

interface Props {
  objects: Related[];
}

const RelatedObjectList = ({ objects }: Props) => {
  return (
    <>
      {objects.length
        ? objects.map((obj) => {
            return (
              <ul>
                <li key={obj.objectId}>
                  <RelatedObjects object={obj} />
                </li>
              </ul>
            );
          })
        : null}
    </>
  );
};

export default RelatedObjectList;
