import React, { useEffect, useState } from "react";
import type { Exhibitions } from "../../apitypes/musuem";
import { useOutletContext } from "react-router-dom";
import { getExhibitions } from "../../Service/MuseumService";
import Table from "../Table/Table";
import { DateFormmater } from "../../Helpers/DateFormmater";

type Props = {};

const Exhibitions = (props: Props) => {
  const configs = [
    {
      label: "Title",
      render: (exb: Exhibitions) => exb.title,
    },
    {
      label: "Citation",
      render: (exb: Exhibitions) => exb.citation?.substring(4),
    },
    {
      label: "Start Date",
      render: (exb: Exhibitions) =>
        exb.begindate && DateFormmater(exb.begindate),
    },
    {
      label: "End Date",
      render: (exb: Exhibitions) => exb.enddate && DateFormmater(exb.enddate),
    },
  ];

  const objectId = useOutletContext<number>();
  const [data, setData] = useState<Exhibitions[]>([]);

  useEffect(() => {
    fetchExhibitions();
  }, []);

  const fetchExhibitions = async () => {
    const exb = await getExhibitions(objectId);
    if (Array.isArray(exb)) {
      setData(exb);
    }
  };

  return (
    <>
      {data?.length ? (
        <div className="mt-5">
          <Table configs={configs} data={data} />
        </div>
      ) : null}
    </>
  );
};

export default Exhibitions;
