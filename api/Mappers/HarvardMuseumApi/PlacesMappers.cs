using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.HarvardMusemApiDTOS;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace api.Mappers.HarvardMuseumApi
{
    public static class PlacesMappers
    {
        public static IEnumerable<RegionDTO.Record> ToRecordFromRegionRoot(this RegionDTO.Root root){
            return root.records.Select(r => new RegionDTO.Record{
                name = r.name,
                id = r.id
            });
        }

        public static IEnumerable<CountryDTO.Record> ToRecordFromCountryRoot(this CountryDTO.Root root){
            return root.records.Select(r => new CountryDTO.Record{
                name = r.name,
                id = r.id,
            });
        }
    }
}