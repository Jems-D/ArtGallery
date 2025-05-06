import React from "react";
import { ObjectMetadata } from "../../apitypes/musuem";
import privacy from "../Card/privacy.svg";
import "../ObjectInformation/ObjectInformation.css";
interface Props {
  objectInfo: ObjectMetadata;
}

const ObjectInformation = ({ objectInfo }: Props) => {
  return (
    <div className="rounded-md shadow bg-applewhite p-3 gap-5 lg:flex ">
      <img
        src={
          typeof objectInfo.primaryImageUrl !== "string" ||
          objectInfo.primaryImageUrl === ""
            ? privacy
            : objectInfo.primaryImageUrl
        }
        className="object-cover rouded-md"
        id="objectimage"
      />
      <div className="flex flex-col">
        {objectInfo.title && (
          <p className="font-serif font-semibold text-2xl text-right">
            {objectInfo.title}
          </p>
        )}
        {objectInfo.technique && (
          <p className="text-right">{objectInfo.technique}</p>
        )}
        {objectInfo.medium && <p className="text-right">{objectInfo.medium}</p>}
        {objectInfo.classification && (
          <p className="text-right">{objectInfo.classification}</p>
        )}
        {objectInfo.culture && (
          <p className="text-right">{objectInfo.culture}</p>
        )}
        {objectInfo.dimensions && (
          <p className="text-right">{objectInfo.dimensions}</p>
        )}
        {objectInfo.provenance && (
          <p className="text-right">{objectInfo.provenance}</p>
        )}

        {objectInfo.people.map((peope) => {
          return (
            peope.name && (
              <p key={peope.personId} className="text-right">
                Artist/s: {peope.name}
              </p>
            )
          );
        })}
      </div>
    </div>
  );
};

export default ObjectInformation;
