﻿using AutoMapper;
using BL.DTO;
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

            CreateMap<(Discount discount, int userId, GeoCoordinate location), DiscountDTO>()
                .ForMember(d => d.DiscountId, source => source.MapFrom(s => s.discount.Id))
                .ForMember(d => d.DiscountName, source => source.MapFrom(s => s.discount.Name))
                .ForMember(d => d.VendorName, source => source.MapFrom(s => s.discount.Vendor.Name))
                .ForMember(d => d.DistanceInMeters, source => source.MapFrom(s => s.discount.PointOfSales
                    .Select(p => new { Distance = (int)s.location.GetDistanceTo(new GeoCoordinate(p.Latitude, p.Longitude)) })
                    .OrderBy(p => p.Distance)
                    .FirstOrDefault().Distance))
                .ForMember(d => d.DiscountRating, source => source.MapFrom(s => s.discount.Assessments.Where(a => a.DiscountId == s.discount.Id).Average(a => a.AssessmentValue)));
        }
    }
}
