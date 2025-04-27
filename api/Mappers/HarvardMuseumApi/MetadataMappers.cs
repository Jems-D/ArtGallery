using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTO.HarvardMusemApiDTOS;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace api.Mappers.HarvardMuseumApi
{
    public static class MetadataMappers
    {
        public static IEnumerable<CardInfoDTO.Record> ToCardInfoFromRoot(this CardInfoDTO.Root root){
            return root.records.Select(s => 
            {
                string imageUrl = (s.imagepermissionlevel != 2 && s.primaryimageurl != null) ? s.primaryimageurl : ""; //adhere to the api rules, when permission is 2, don't display the pic
                return new CardInfoDTO.Record{
                    title = s.title,
                    description = s.description,
                    classification = s.classification,
                    technique = s.technique,
                    primaryimageurl = imageUrl,
                    objectid = s.objectid
                };
            });
        }

        public static ObjectMetadataDTO.Record? ToObjMtdFromRoot(this ObjectMetadataDTO.Root root){
            return root.records.Select(s => new ObjectMetadataDTO.Record{
                id = s.id,
                objectid = s.objectid,
                title = s.title,
                description = s.description,
                people = s.people,
                url = s.url,
                dated = s.dated,
                dimensions = s.dimensions,
                primaryimageurl = s.primaryimageurl,
                medium = s.medium,
                classification  = s.classification,
                technique = s.technique,
                provenance = s.provenance

            }).FirstOrDefault();
        }

        public static IEnumerable<RelatedToDTO.RecordDTO> ToRecordFromRelatedRoot(this RelatedToDTO.Root root){
            return root.records.Select(s => new RelatedToDTO.RecordDTO{
                title = s.title,
                objectid = s.objectid
            });
        }


        public static List<ExhibitionDTO.Exhibition> ToExhibitionFromExhibitionRoot(this ExhibitionDTO.Root root){
            return root.records
                        .Where(record => record.exhibitions != null)
                        .SelectMany(record => record.exhibitions)
                        .ToList();
        }

        public static List<PublicationDTO.Publication> ToPublicationFromPublicationRoot(this PublicationDTO.Root root){
            return root.records
                        .Where(record => record.publications != null)
                        .SelectMany(record => record.publications)
                        .ToList();
        }

        public static List<PersonOtherWorksDTO.RecordDTO> ToRecordFromOtherWorksDTO(this PersonOtherWorksDTO.Root root){
            return root.records.Select(s => new PersonOtherWorksDTO.RecordDTO{
                title = s.title,
                objectid = s.objectid
            }).ToList();
        }

    }
}