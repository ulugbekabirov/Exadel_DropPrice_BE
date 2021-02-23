using AutoMapper;
using BL.DTO;
using DAL.Entities;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using WebApi.ViewModels;

namespace BL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Town, TownDTO>()
                .ForMember(t => t.TownName, source => source.MapFrom(s => s.Name.Current))
                .ReverseMap();

            CreateMap<User, UserDTO>()
                .ForMember(u => u.FIO, source => source.MapFrom(s => $"{s.FirstName} {s.LastName} {s.Patronymic}"))
                .ForMember(u => u.OfficeLatitude, source => source.MapFrom(s => s.Office.Latitude))
                .ForMember(u => u.OfficeLongitude, source => source.MapFrom(s => s.Office.Longitude))
                .ForMember(u => u.Office, source => source.MapFrom(s => s.Office.Name));
            CreateMap<IEnumerable<string>, UserDTO>()
                .ForMember(u => u.Roles, source => source.MapFrom(s => s));

            CreateMap<Tag, TagDTO>()
                .ForMember(t => t.TagName, source => source.MapFrom(s => s.Name))
                .ForMember(t => t.TagId, source => source.MapFrom(s => s.Id))
                .ReverseMap();

            CreateMap<SavedDiscount, SavedDTO>()
                .ForMember(s => s.DiscountID, source => source.MapFrom(s => s.DiscountId))
                .ForMember(s => s.IsSaved, source => source.MapFrom(s => s.IsSaved));

            CreateMap<PointOfSale, PointOfSaleDTO>()
                .ForMember(d => d.Latitude, source => source.MapFrom(s => s.Location.Y))
                .ForMember(d => d.Longitude, source => source.MapFrom(s => s.Location.X))
                .ReverseMap();

            CreateMap<PointOfSale, PointOfSaleViewModel>()
                .ForMember(d => d.Latitude, source => source.MapFrom(s => s.Location.Y))
                .ForMember(d => d.Longitude, source => source.MapFrom(s => s.Location.X));
            CreateMap<PointOfSaleViewModel, PointOfSale>()
                .AfterMap((source, pointOFSale) =>
                {
                    pointOFSale.Location = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326).CreatePoint(new Coordinate(source.Longitude, source.Latitude));
                });

            CreateMap<AssessmentViewModel, Assessment>()
                .ReverseMap();

            CreateMap<Ticket, TicketDTO>()
                .ForMember(t => t.DiscountId, source => source.MapFrom(s => s.DiscountId))
                .ForMember(t => t.VendorId, source => source.MapFrom(s => s.Discount.Vendor.Id))
                .ForMember(t => t.FirstName, source => source.MapFrom(s => s.User.FirstName))
                .ForMember(t => t.LastName, source => source.MapFrom(s => s.User.LastName))
                .ForMember(t => t.Patronymic, source => source.MapFrom(s => s.User.Patronymic))
                .ForMember(t => t.VendorName, source => source.MapFrom(s => s.Discount.Vendor.Name))
                .ForMember(t => t.VendorEmail, source => source.MapFrom(s => s.Discount.Vendor.Email))
                .ForMember(t => t.VendorPhone, source => source.MapFrom(s => s.Discount.Vendor.Phone))
                .ForMember(t => t.DiscountAmount, source => source.MapFrom(s => s.Discount.DiscountAmount))
                .ForMember(t => t.PromoCode, source => source.MapFrom(s => s.Discount.PromoCode))
                .ForMember(t => t.DiscountActivity, source => source.MapFrom(s => s.Discount.ActivityStatus))
                .AfterMap((source, dto) =>
                {
                    dto.IsExpired = source.OrderDate.Date != DateTime.Now.Date;
                });

            CreateMap<VendorViewModel, Vendor>()
               .ForMember(v => v.Name, source => source.MapFrom(v => v.VendorName))
               .ForMember(v => v.PointOfSales, source => source.Ignore())
               .ReverseMap();

            CreateMap<Vendor, VendorDTO>()
              .ForMember(v => v.VendorId, source => source.MapFrom(s => s.Id))
              .ForMember(v => v.VendorName, source => source.MapFrom(s => s.Name));

            CreateMap<DiscountViewModel, Discount>()
                .ForMember(d => d.Name, source => source.MapFrom(s => s.DiscountName))
                .ForMember(d => d.PointOfSales, source => source.Ignore())
                .ForMember(d => d.Vendor, source => source.Ignore())
                .ForMember(d => d.Tags, source => source.Ignore());
            CreateMap<Discount, DiscountViewModel>()
                .ForMember(d => d.DiscountName, source => source.MapFrom(s => s.Name))
                .ForMember(d => d.PointOfSales, source => source.Ignore())
                .ForMember(d => d.Tags, source => source.Ignore());

            CreateMap<Discount, DiscountDTO>()
                .ForMember(d => d.DiscountId, source => source.MapFrom(s => s.Id))
                .ForMember(d => d.DiscountName, source => source.MapFrom(s => s.Name))
                .ForMember(d=>d.ImageId, source=>source.MapFrom(s=>s.Vendor.ImageId))
                .ReverseMap()
                .ForAllOtherMembers(d => d.Ignore());
            CreateMap<Discount, DiscountDTO>()
                .ForMember(d => d.DiscountName, source => source.MapFrom(s => s.Name))
                .ForMember(d => d.DiscountId, source => source.MapFrom(s => s.Id))
                .ForMember(d => d.PromoCode, act => act.NullSubstitute("Not Available"));

            CreateMap<Discount, ArchivedDiscountDTO>()
                .ForMember(d => d.DiscountId, source => source.MapFrom(s => s.Id));

            CreateMap<Discount, DiscountStatisticDTO>()
                .ForMember(d => d.DiscountId, soucre => soucre.MapFrom(s => s.Id))
                .ForMember(d => d.DiscountName, source => source.MapFrom(s => s.Name));

            CreateMap<ConfigVariableDTO, ConfigVariable>()
                .ForMember(v => v.Id, source => source.MapFrom(s => s.ConfigId))
                .ForMember(v => v.Value, source => source.MapFrom(s => s.ConfigValue))
                .ForMember(v => v.Description, source => source.MapFrom(s => s.ConfigDescription))
                .ForMember(v => v.Name, source => source.MapFrom(s => s.ConfigName))
                .ReverseMap();

            CreateMap<Image, ImageDTO>()
                .ReverseMap();
        }
    }
}
