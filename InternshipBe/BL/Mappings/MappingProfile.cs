using AutoMapper;
using BL.DTO;
using BL.Models;
using DAL.Entities;
using GeoCoordinatePortable;
using System.Collections.Generic;
using System.Linq;

namespace BL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Town, TownDTO>()
                .ForMember(t => t.TownName, source => source.MapFrom(s => s.Name));
            CreateMap<TownDTO, Town>()
                .ForMember(t => t.Name, source => source.MapFrom(s => s.TownName));

            CreateMap<User, UserDTO>()
                .ForMember(u => u.OfficeLatitude, source => source.MapFrom(s => s.Office.Latitude))
                .ForMember(u => u.OfficeLongitude, source => source.MapFrom(s => s.Office.Longitude));
            CreateMap<IEnumerable<string>, UserDTO>()
                .ForMember(u => u.Roles, source => source.MapFrom(s => s));
            
            CreateMap<Tag, TagDTO>()
                .ForMember(t => t.TagName, source => source.MapFrom(s => s.Name))
                .ForMember(t => t.TagId, source => source.MapFrom(s => s.Id));
            CreateMap<TagDTO, Tag>()
                .ForMember(t => t.Name, source => source.MapFrom(s => s.TagName))
                .ForMember(t => t.Id, source => source.MapFrom(s => s.TagId)); ;

            CreateMap<Vendor, VendorDTO>()
              .ForMember(v => v.VendorId, source => source.MapFrom(s => s.Id))
              .ForMember(v => v.VendorName, source => source.MapFrom(s => s.Name));
            //.AfterMap((entity, dto)=> dto.VendorRating = entity.Discounts.Select(d => d.Assessments.Any)? )

            CreateMap<VendorDTO, Vendor>()
                .ForMember(v => v.Id, source => source.MapFrom(s => s.VendorId))
                .ForMember(v => v.Name, source => source.MapFrom(s => s.VendorName));

            CreateMap<Discount, DiscountModel>();
            CreateMap<int, DiscountModel>()
                .ForMember(d => d.UserId, source => source.MapFrom(s => s));
            CreateMap<GeoCoordinate, DiscountModel>()
                .ForMember(d => d.Location, source => source.MapFrom(s => s));

            CreateMap<DiscountModel, DiscountDTO>()
                .ForMember(d => d.DiscountId, source => source.MapFrom(s => s.Discount.Id))
                .ForMember(d => d.VendorId, source => source.MapFrom(s => s.Discount.Vendorid))
                .ForMember(d => d.VendorName, soucre => soucre.MapFrom(s => s.Discount.Vendor.Name))
                .ForMember(d => d.DiscountName, source => source.MapFrom(s => s.Discount.Name))
                .ForMember(d => d.DiscountAmount, source => source.MapFrom(s => s.Discount.DiscountAmount))
                .ForMember(d => d.EndDate, source => source.MapFrom(s => s.Discount.EndDate))
                .AfterMap((source, dto) =>
                {
                    dto.DistanceInMeters = source.Discount.PointOfSales
                        .Select(p => new { Distance = (int)source.Location.GetDistanceTo(new GeoCoordinate(p.Latitude, p.Longitude)) })
                        .OrderBy(p => p.Distance).FirstOrDefault().Distance;

                    dto.DiscountRating = source.Discount.Assessments.Any() ?
                    source.Discount.Assessments.Where(a => a.DiscountId == source.Discount.Id).Average(a => a.AssessmentValue) : null;

                    dto.IsSaved = source.Discount.SavedDiscounts.Any() ?
                    source.Discount.SavedDiscounts.Any(sd => sd.DiscountId == dto.DiscountId && sd.UserId == source.UserId) : null;
                });
        }
    }
}
