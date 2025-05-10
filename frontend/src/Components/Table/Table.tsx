import React from "react";
import { Config } from "tailwindcss";
import type { Publications } from "../../apitypes/musuem";

interface Props {
  configs: any;
  data: unknown[];
}

const Table = ({ configs, data }: Props) => {
  return (
    <div>
      <table>
        <thead className="border-b border-gray-500/50">
          <tr>
            {configs.map((configs: any, index: Number) => {
              return (
                <th
                  key={`th${index}`}
                  className="font-semibold font-sans text-left p-2"
                >
                  {configs.label}
                </th>
              );
            })}
          </tr>
        </thead>
        <tbody>
          {data.map((data, index) => {
            return (
              <tr
                key={`index-${index}`}
                className="border-b border-gray-500/50"
              >
                {configs.map((config: any, index: number) => {
                  return (
                    <td
                      key={`cell-${index}`}
                      className={
                        index === 0
                          ? "font-semibold p-2"
                          : "opacity-80 text-gray-900 p-2"
                      }
                    >
                      {config.render(data)}
                    </td>
                  );
                })}
              </tr>
            );
          })}
        </tbody>
      </table>
    </div>
  );
};

export default Table;
