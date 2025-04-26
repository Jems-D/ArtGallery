using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.HarvardMusemApiDTOS;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace api.Mappers.HarvardMuseumApi
{
    public static class CategoryMappers
    {
        public static IEnumerable<PropDTO.Record> ToRecordFromPropRoot(this PropDTO.Root root){
            return root.records.Select(r => new PropDTO.Record{
                name = r.name,
                id = r.id
            });
        }
    }
}