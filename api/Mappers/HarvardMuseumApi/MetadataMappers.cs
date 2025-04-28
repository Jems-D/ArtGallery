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
        public static IEnumerable<CardInfoDTO.Record>? ToCardInfoFromRoot(this CardInfoDTO.Root root){
            return root.Records?.Select(s => 
            {
                string imageUrl = (s.ImagePermissionLevel != 2 && s.PrimaryImageUrl != null) ? s.PrimaryImageUrl : ""; //adhere to the api rules, when permission is 2, don't display the pic
                return new CardInfoDTO.Record{
                    Title = s.Title,
                    Description = s.Description,
                    Classification = s.Classification,
                    Technique = s.Technique,
                    PrimaryImageUrl = imageUrl,
                    ObjectId = s.ObjectId
                };
            });
        }

        public static ObjectMetadataDTO.Record? ToObjMtdFromRoot(this ObjectMetadataDTO.Root root){
            return root.Records?.Select(s => new ObjectMetadataDTO.Record{
                Id = s.Id,
                ObjectId = s.ObjectId,
                Title = s.Title,
                Description = s.Description,
                People = s.People,
                Url = s.Url,
                Dated = s.Dated,
                Dimensions = s.Dimensions,
                PrimaryImageUrl = s.PrimaryImageUrl,
                Medium = s.Medium,
                Classification  = s.Classification,
                Technique = s.Technique,
                Provenance = s.Provenance

            }).FirstOrDefault();
        }

        public static IEnumerable<RelatedToDTO.RecordDTO>? ToRecordFromRelatedRoot(this RelatedToDTO.Root root){
            return root.Records?.Select(s => new RelatedToDTO.RecordDTO{
                Title = s.Title,
                ObjectId = s.ObjectId
            });
        }


        public static List<ExhibitionDTO.Exhibition>? ToExhibitionFromExhibitionRoot(this ExhibitionDTO.Root root){
            return root.Records?
                        .Where(record => record.Exhibitions != null)
                        .SelectMany(record => record.Exhibitions)
                        .ToList();
        }

        public static List<PublicationDTO.Publication>? ToPublicationFromPublicationRoot(this PublicationDTO.Root root){
            return root.Records?
                        .Where(record => record.Publications != null)
                        .SelectMany(record => record.Publications)
                        .ToList();
        }

        public static List<PersonOtherWorksDTO.RecordDTO>? ToRecordFromOtherWorksDTO(this PersonOtherWorksDTO.Root root){
            return root.Records?.Select(s => new PersonOtherWorksDTO.RecordDTO{
                Title = s.Title,
                ObjectId = s.ObjectId
            }).ToList();
        }

    }
}