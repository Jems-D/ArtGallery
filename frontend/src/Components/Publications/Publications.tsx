import React, { useEffect, useState } from "react";
import type { Publications } from "../../apitypes/musuem";
import { useOutletContext } from "react-router-dom";
import { getPubllications } from "../../Service/MuseumService";
import Table from "../Table/Table";

interface Props {}

const Publications = (props: Props) => {
  const configs = [
    {
      label: "Title",
      render: (pub: Publications) => pub.title,
    },
    {
      label: "Citation",
      render: (pub: Publications) => pub.citation,
    },
    {
      label: "Place",
      render: (pub: Publications) => pub.publicationPlace,
    },
    {
      label: "Format",
      render: (pub: Publications) => pub.format,
    },
    {
      label: "Year",
      render: (pub: Publications) => pub.publicationYear,
    },
  ];
  const objectId = useOutletContext<number>();
  const [data, setData] = useState<Publications[]>([]);

  useEffect(() => {
    fetchPublications();
  }, []);

  const fetchPublications = async () => {
    const publications = await getPubllications(objectId);
    if (Array.isArray(publications)) {
      setData(publications);
    }
  };

  return (
    <>
      {data.length ? (
        <div className="mt-5">
          <Table configs={configs} data={data} />
        </div>
      ) : null}
    </>
  );
};

export default Publications;
