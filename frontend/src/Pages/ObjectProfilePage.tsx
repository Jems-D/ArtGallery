import React, { useEffect, useState } from "react";
import ObjectInformation from "../Components/ObjectInformation/ObjectInformation";
import { ObjectMetadata, Related } from "../apitypes/musuem";
import { useParams } from "react-router-dom";
import {
  getObjectInformation,
  getRelatedObjects,
} from "../Service/MuseumService";
import RelatedObjectList from "../Components/RelatedObject/RelatedObjectList";
interface Props {}

const ObjectProfilePage = (props: Props) => {
  const [objInfo, setObjInfo] = useState<ObjectMetadata>();
  const [relatedObjs, setRelated] = useState<Related[]>([]);
  const { objectid } = useParams<string>();
  const numObjectId = Number(objectid);

  useEffect(() => {
    fetchObjectInfo();
    fetchRelated();
  }, []);

  const fetchObjectInfo = async () => {
    const objectInfo = await getObjectInformation(numObjectId);
    setObjInfo(objectInfo);
  };

  const fetchRelated = async () => {
    const related = await getRelatedObjects(numObjectId);
    if (related) {
      setRelated(related);
    }
  };

  return (
    <div className="mt-10 mx-6">
      {typeof objInfo !== "undefined" && (
        <div>
          <ObjectInformation objectInfo={objInfo} />
          <RelatedObjectList objects={relatedObjs} />
        </div>
      )}
    </div>
  );
};

export default ObjectProfilePage;
