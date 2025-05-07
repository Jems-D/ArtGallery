import React, { useEffect, useState } from "react";
import ObjectInformation from "../Components/ObjectInformation/ObjectInformation";
import {
  ObjectMetadata,
  OtherWorks,
  People,
  Related,
} from "../apitypes/musuem";
import { useParams } from "react-router-dom";
import {
  getObjectInformation,
  getOtherWorksOfArtist,
  getRelatedObjects,
} from "../Service/MuseumService";
interface Props {}

const ObjectProfilePage = (props: Props) => {
  const [objInfo, setObjInfo] = useState<ObjectMetadata>();
  const [relatedObjs, setRelated] = useState<Related[]>([]);
  const [otherWrks, setOtherWorks] = useState<OtherWorks[]>([]);
  const [personId, setPersonId] = useState<number>(0);
  const { objectid } = useParams<string>();
  const numObjectId = Number(objectid);

  useEffect(() => {
    fetchObjectInfo();
    fetchRelated();
    fetchOtherWorks();
  }, []);

  const fetchObjectInfo = async () => {
    const objectInfo = await getObjectInformation(numObjectId);
    if (objectInfo) {
      setObjInfo(objectInfo);
      setPersonId(Number(objInfo?.people[0].personId));
    }
  };

  const fetchRelated = async () => {
    const related = await getRelatedObjects(numObjectId);
    if (related) {
      setRelated(related);
    }
  };

  const fetchOtherWorks = async () => {
    const otherWorks = await getOtherWorksOfArtist(personId, numObjectId);
    if (otherWorks) {
      setOtherWorks(otherWorks);
    }
  };

  return (
    <div className="mt-10 mx-6">
      {typeof objInfo !== "undefined" && (
        <div>
          <ObjectInformation
            objectInfo={objInfo}
            relatedObjects={relatedObjs}
            otherWorks={otherWrks}
          />
        </div>
      )}
    </div>
  );
};

export default ObjectProfilePage;
