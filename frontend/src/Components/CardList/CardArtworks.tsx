import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import CardList from "./CardList";
import { SearchResults } from "../../apitypes/musuem";
import { getArtworksBasedOnCategory } from "../../Service/MuseumService";
import Pagination from "../Comment/Pagination/Pagination";

type Props = {};

const CardArtworks = (props: Props) => {
  const { category } = useParams<string>();
  const { id } = useParams<string>();
  const numId = Number(id);
  const [artWork, setArtworks] = useState<SearchResults[]>([]);
  const [currentPage, setCurrentPage] = useState<number>(1);
  const [pageSize, setPageSize] = useState<number>(20);
  const [totalCount, setTotalCount] = useState<number>(0);

  useEffect(() => {
    fetchArtworksBasedOnCategory();
  }, [currentPage]);

  const fetchArtworksBasedOnCategory = async () => {
    const arts = await getArtworksBasedOnCategory(
      numId,
      currentPage,
      category!
    );
    if (arts) {
      if (Array.isArray(arts.data.result)) {
        setArtworks(arts.data.result);
        setPageSize(arts.data.pageSize);
        setTotalCount(arts.data.totaCount);
      }
    }
  };

  const handlePagination = (e: number) => {
    setCurrentPage(e);
  };

  return (
    <>
      {artWork.length ? (
        <div className="mx-6 mt-10 mb-5">
          <CardList cardInfo={artWork} />
          <div className="grid place-items-end">
            <Pagination
              postPerPage={pageSize}
              length={totalCount}
              handlePagination={handlePagination}
              currentPage={currentPage}
            />
          </div>
        </div>
      ) : null}
    </>
  );
};

export default CardArtworks;
