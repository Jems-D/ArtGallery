import React from "react";
import { ObjectMetadata, OtherWorks, Related } from "../../apitypes/musuem";
import privacy from "../Card/privacy.svg";
import "../ObjectInformation/ObjectInformation.css";
import RelatedObjectList from "../RelatedObject/RelatedObjectList";
import SameArtistList from "../MoreFromSameArtist/SameArtistList";
interface Props {
  objectInfo: ObjectMetadata;
  relatedObjects: Related[];
  otherWorks: OtherWorks[];
}

const ObjectInformation = ({
  objectInfo,
  relatedObjects,
  otherWorks,
}: Props) => {
  return (
    <div className="rounded-md shadow bg-applewhite p-3 gap-5 lg:flex ">
      <div className="w-fit">
        <img
          src={
            typeof objectInfo.primaryImageUrl !== "string" ||
            objectInfo.primaryImageUrl === ""
              ? privacy
              : objectInfo.primaryImageUrl
          }
          className="object-scale-down rouded-md"
          id="objectimage"
        />
      </div>
      <div className=" flex flex-col flex-1">
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
        {objectInfo.description && (
          <p className="text-right text-wrap">{objectInfo.description}</p>
        )}
        {objectInfo.people ? (
          <>
            {objectInfo.people.map((peope) => {
              return (
                peope.name && (
                  <p key={`pepe--${peope.personId}`} className="text-right">
                    Artist/s: {peope.name}
                  </p>
                )
              );
            })}
          </>
        ) : null}

        {relatedObjects.length ? (
          <div className="flex flex-col justify-end mt-5">
            <span className="text-sm text-right">Related works: </span>
            <RelatedObjectList objects={relatedObjects} />
          </div>
        ) : null}

        {otherWorks.length ? (
          <div className="flex flex-col justify-end mt-5">
            <span className="text-sm text-right">
              {" "}
              Other artworks from the artist:
            </span>
            <SameArtistList otherWorks={otherWorks} />
          </div>
        ) : null}
      </div>
    </div>
  );
};

export default ObjectInformation;
