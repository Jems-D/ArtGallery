import React from "react";
import { OtherWorks } from "../../apitypes/musuem";
import SameArtist from "./SameArtist";

interface Props {
  otherWorks: OtherWorks[];
}

const SameArtistList = ({ otherWorks }: Props) => {
  return (
    <ul>
      {otherWorks.map((other) => {
        return (
          <li className="" key={other.objectId}>
            <SameArtist otherWorks={other} />
          </li>
        );
      })}
    </ul>
  );
};

export default SameArtistList;
