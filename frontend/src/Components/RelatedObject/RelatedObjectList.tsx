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
        ? objects.map((obj, index) => {
            return (
              <ul className="">
                <li key={index}>
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
