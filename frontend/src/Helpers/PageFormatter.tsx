export const getPageNumbers = (
  totalPages: number,
  currentPage: number,
  maxButtons: number = 5
): (number | string)[] => {
  const pages: (number | string)[] = [];

  if (totalPages <= maxButtons) {
    for (let i = 1; i <= totalPages; i++) {
      pages.push(i);
    }
  } else {
    const leftSide = Math.max(2, currentPage - 1);
    const rightSide = Math.min(totalPages - 1, currentPage + 1);

    pages.push(1);

    if (leftSide > 2) {
      pages.push("...");
    }

    for (let i = leftSide; i <= rightSide; i++) {
      pages.push(i);
    }

    if (rightSide <= totalPages - 1) {
      pages.push("...");
    }

    pages.push(totalPages);
  }
  return pages;
};
