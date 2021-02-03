using AutoMapper;
using BL.DTO;
using BL.Models;
using DAL.Entities;
using GeoCoordinatePortable;
using Shared.Extensions;
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
                .ForMember(t => t.Id, source => source.MapFrom(s => s.TagId));

            CreateMap<Ticket, TicketDTO>();

            CreateMap<Vendor, VendorDTO>()
              .ForMember(v => v.VendorId, source => source.MapFrom(s => s.Id))
              .ForMember(v => v.VendorName, source => source.MapFrom(s => s.Name))
              .AfterMap((source, dto) =>
              {
                  dto.VendorRating = source.GetVendorRating();
              });
            CreateMap<VendorDTO, Vendor>()
                .ForMember(v => v.Id, source => source.MapFrom(s => s.VendorId))
                .ForMember(v => v.Name, source => source.MapFrom(s => s.VendorName));

            CreateMap<DiscountModel, DiscountDTO>()
                .ForMember(d => d.DiscountId, source => source.MapFrom(s => s.Discount.Id))
                .ForMember(d => d.VendorId, source => source.MapFrom(s => s.Discount.Vendorid))
                .ForMember(d => d.VendorName, soucre => soucre.MapFrom(s => s.Discount.Vendor.Name))
                .ForMember(d => d.DiscountName, source => source.MapFrom(s => s.Discount.Name))
                .ForMember(d => d.Description, source => source.MapFrom(s => s.Discount.Description))
                .ForMember(d => d.ActivityStatus, source => source.MapFrom(s => s.Discount.ActivityStatus))
                .ForMember(d => d.DiscountAmount, source => source.MapFrom(s => s.Discount.DiscountAmount))
                .ForMember(d => d.StartDate, source => source.MapFrom(s => s.Discount.StartDate))
                .ForMember(d => d.PromoCode, source => source.MapFrom(s => s.Discount.Promocode))
                .ForMember(d => d.EndDate, source => source.MapFrom(s => s.Discount.EndDate))
                .AfterMap((source, dto) =>
                {
                    var pointOfSale = source.Discount.GetAddressAndDistanceOfPointOfSale(source.Location);
                    dto.Address = pointOfSale.Item1;
                    dto.DistanceInMeters = pointOfSale.Item2;
                    dto.DiscountRating = source.Discount.DiscountRating();
                    dto.IsSaved = source.Discount.IsSavedDiscount(source.UserId);
                    dto.Tags = source.Discount.GetTags();
                });
        }
    }
}
