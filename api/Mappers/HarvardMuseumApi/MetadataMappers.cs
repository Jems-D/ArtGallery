using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.HarvardMusemApiDTOS;

namespace api.Mappers.HarvardMuseumApi
{
    public static class MetadataMappers
    {
        public static IEnumerable<CardInfoDTO.Record> ToCardInfoFromRoot(this CardInfoDTO.Root root){
            return root.records.Select(s => new CardInfoDTO.Record{
                title = s.title,
                description = s.description,
                classification = s.classification,
                technique = s.technique,
                primaryimageurl = s.primaryimageurl,
                objectid = s.objectid
            });
        }
    }
}