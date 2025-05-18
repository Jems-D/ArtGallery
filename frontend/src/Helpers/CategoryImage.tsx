import classification from "../Components/Categories/Images/classification.jpg";
import culture from "../Components/Categories/Images/culture.jpg";
import medium from "../Components/Categories/Images/medium.jpg";
import period from "../Components/Categories/Images/period.jpg";
import person from "../Components/Categories/Images/person.jpg";
import place from "../Components/Categories/Images/place.jpg";
import technique from "../Components/Categories/Images/technique.jpg";
import century from "../Components/Categories/Images/century.jpg";

export const CategoryImage = (prop: string): string => {
  if (prop === "classification") {
    prop = classification;
  } else if (prop === "culture") {
    prop = culture;
  } else if (prop === "medium") {
    prop = medium;
  } else if (prop === "period") {
    prop = period;
  } else if (prop === "person") {
    prop = person;
  } else if (prop === "place") {
    prop = place;
  } else if (prop === "technique") {
    prop = technique;
  } else if (prop === "century") {
    prop = century;
  }
  return prop;
};
