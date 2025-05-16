import React, { useEffect, useState } from "react";
import ObjectInformation from "../Components/ObjectInformation/ObjectInformation";
import {
  ObjectMetadata,
  OtherWorks,
  People,
  Related,
} from "../apitypes/musuem";
import { Outlet, useParams } from "react-router-dom";
import {
  getObjectInformation,
  getOtherWorksOfArtist,
  getRelatedObjects,
} from "../Service/MuseumService";
import InsideNavBar from "../Components/InsideNavbar/InsideNavbar";
import CommentForm from "../Components/Comment/CommentForm/CommentForm";
import Review from "../Components/Comment/Review";
interface Props {}

const ObjectProfilePage = (props: Props) => {
  const [objInfo, setObjInfo] = useState<ObjectMetadata>();
  const [relatedObjs, setRelated] = useState<Related[]>([]);
  const [otherWrks, setOtherWorks] = useState<OtherWorks[]>([]);
  const [personId, setPersonId] = useState<number>(0);
  const { objectid } = useParams<string>();
  const numObjectId = Number(objectid);

  interface CommentInputForm {
    title: string;
    content: string;
    rating: number;
  }

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
        <div className="flex flex-col">
          <ObjectInformation
            objectInfo={objInfo}
            relatedObjects={relatedObjs}
            otherWorks={otherWrks}
          />
          <div className="flex mt-5 flex-col lg:flex-row">
            <div className="flex-1 flex-col mr-10">
              <section className="">
                <InsideNavBar />
                <Outlet context={numObjectId} />
              </section>
            </div>
            <div className="flex-1 mt-10 lg:mt-0">
              <Review objectId={numObjectId} />
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default ObjectProfilePage;
