import React, { useEffect, useState } from "react";
import { getCategories } from "../Service/MuseumService";
import { useParams } from "react-router-dom";
import {
  Categories,
  CategoriesSearchResult,
  CategorySearch,
} from "../apitypes/musuem";
import CategoriesList from "../Components/Categories/CategoriesList";
import Pagination from "../Components/Comment/Pagination/Pagination";

interface Props {}

const CategoriesPage = ({}: Props) => {
  const { category } = useParams<string>();
  const property = category!.toLowerCase();
  const [categories, setCategories] = useState<CategorySearch[]>([]);
  const [propName, setPropName] = useState<string>("");
  const [postPerpage, setPostPerPage] = useState<number>(0);
  const [totalCount, setTotalCount] = useState<number>(0);
  const [currentPage, setCurrentPage] = useState<number>(1);

  useEffect(() => {
    fetchCategories();
    console.log("hello");
  }, [, currentPage]);

  const fetchCategories = async () => {
    const categories = await getCategories(currentPage, property);
    if (categories) {
      if (Array.isArray(categories.data.result)) {
        setCategories(categories.data.result);
        setPropName(categories.data.type);
        setTotalCount(categories.data.totaCount);
        setPostPerPage(categories.data.pageSize);
      } else {
        console.log("Not an array");
      }
    }
  };

  const handlePagination = (e: number) => {
    setCurrentPage(e);
  };

  return (
    <div className="mx-6 mt-10">
      {categories.length ? (
        <>
          <CategoriesList categories={categories} propName={propName} />
          <div className="grid place-items-end">
            <Pagination
              postPerPage={postPerpage}
              length={totalCount}
              handlePagination={handlePagination}
              currentPage={currentPage}
            />
          </div>
        </>
      ) : null}
    </div>
  );
};

export default CategoriesPage;
