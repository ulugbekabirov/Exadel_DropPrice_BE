using AutoMapper;
using BL.DTO;
using BL.Extensions;
using BL.Models;
using DAL.Entities;
using Shared.Extensions;
using Shared.ViewModels;
using System.Collections.Generic;
using WebApi.ViewModels;

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
                .ForMember(u => u.FIO, source => source.MapFrom(s => $"{s.FirstName} {s.LastName} {s.Patronymic}"))
                .ForMember(u => u.OfficeLatitude, source => source.MapFrom(s => s.Office.Latitude))
                .ForMember(u => u.OfficeLongitude, source => source.MapFrom(s => s.Office.Longitude))
                .ForMember(u => u.Office, source => source.MapFrom(s => s.Office.Name));
            CreateMap<IEnumerable<string>, UserDTO>()
                .ForMember(u => u.Roles, source => source.MapFrom(s => s));

            CreateMap<Tag, TagDTO>()
                .ForMember(t => t.TagName, source => source.MapFrom(s => s.Name))
                .ForMember(t => t.TagId, source => source.MapFrom(s => s.Id));
            CreateMap<TagDTO, Tag>()
                .ForMember(t => t.Name, source => source.MapFrom(s => s.TagName))
                .ForMember(t => t.Id, source => source.MapFrom(s => s.TagId));

            CreateMap<SavedDiscount, SavedDTO>()
                .ForMember(s => s.DiscountID, source => source.MapFrom(s => s.DiscountId))
                .ForMember(s => s.IsSaved, source => source.MapFrom(s => s.IsSaved));

            CreateMap<PointOfSale, PointOfSaleDTO>();
            CreateMap<PointOfSaleViewModel, PointOfSale>().ReverseMap();

            CreateMap<AssessmentViewModel, Assessment>().ReverseMap();

            CreateMap<Ticket, TicketDTO>()
                .ForMember(t => t.FirstName, source => source.MapFrom(s => s.User.FirstName))
                .ForMember(t => t.LastName, source => source.MapFrom(s => s.User.LastName))
                .ForMember(t => t.Patronymic, source => source.MapFrom(s => s.User.Patronymic))
                .ForMember(t => t.VendorName, source => source.MapFrom(s => s.Discount.Vendor.Name))
                .ForMember(t => t.VendorEmail, source => source.MapFrom(s => s.Discount.Vendor.Email))
                .ForMember(t => t.VendorPhone, source => source.MapFrom(s => s.Discount.Vendor.Phone))
                .ForMember(t => t.DiscountAmount, source => source.MapFrom(s => s.Discount.DiscountAmount))
                .ForMember(t => t.PromoCode, source => source.MapFrom(s => s.Discount.PromoCode))
                .AfterMap((source, dto) =>
                {
                    dto.IsExpired = source.IsExpired();
                });

            CreateMap<Discount, DiscountStatisticDTO>()
                .ForMember(d => d.DiscountRating, source => source.MapFrom(s => s.DiscountRating()))
                .ForMember(d => d.TicketCount, source => source.MapFrom(s => s.GetTicketCount()));

            CreateMap<VendorViewModel, Vendor>();
            CreateMap<Vendor, VendorViewModel>();

            CreateMap<Vendor, VendorDTO>()
              .ForMember(v => v.VendorId, source => source.MapFrom(s => s.Id))
              .ForMember(v => v.VendorName, source => source.MapFrom(s => s.Name))
              .AfterMap((source, dto) =>
              {
                  dto.VendorRating = source.GetVendorRating();
                  dto.TicketCount = source.GetTicketCount();
              });
            CreateMap<VendorDTO, Vendor>()
                .ForMember(v => v.Id, source => source.MapFrom(s => s.VendorId))
                .ForMember(v => v.Name, source => source.MapFrom(s => s.VendorName));

            CreateMap<Discount, DiscountDTO>()
                .ForMember(d => d.DiscountId, source => source.MapFrom(s => s.Id))
                .ForMember(d => d.DiscountName, source => source.MapFrom(s => s.Name))
                .ReverseMap()
                .ForAllOtherMembers(d => d.Ignore());

            CreateMap<Discount, ArchivedDiscountDTO>();

            CreateMap<DiscountViewModel, Discount>()
                .ForMember(d => d.Name, source => source.MapFrom(s => s.DiscountName))
                .ForMember(d => d.Tags, source => source.Ignore())
                .ForMember(d => d.PointOfSales, source => source.Ignore());
            CreateMap<Discount, DiscountViewModel>()
                .ForMember(d => d.DiscountName, source => source.MapFrom(s => s.Name))
                .ForMember(d => d.VendorName, source => source.MapFrom(s => s.Vendor.Name))
                .ForMember(d => d.PointOfSales, source => source.Ignore())
                .ForMember(d => d.Tags, source => source.Ignore());

            CreateMap<DiscountModel, DiscountDTO>()
                .ForMember(d => d.DiscountId, source => source.MapFrom(s => s.Discount.Id))
                .ForMember(d => d.VendorId, source => source.MapFrom(s => s.Discount.VendorId))
                .ForMember(d => d.DiscountName, source => source.MapFrom(s => s.Discount.Name))
                .ForMember(d => d.VendorName, source => source.MapFrom(s => s.Discount.Vendor.Name))
                .ForMember(d => d.Description, source => source.MapFrom(s => s.Discount.Description))
                .ForMember(d => d.ActivityStatus, source => source.MapFrom(s => s.Discount.ActivityStatus))
                .ForMember(d => d.DiscountAmount, source => source.MapFrom(s => s.Discount.DiscountAmount))
                .ForMember(d => d.StartDate, source => source.MapFrom(s => s.Discount.StartDate))
                .ForMember(d => d.PromoCode, source => source.MapFrom(s => s.Discount.PromoCode))
                .ForMember(d => d.EndDate, source => source.MapFrom(s => s.Discount.EndDate))
                .ForMember(d => d.DistanceInMeters, source => source.MapFrom(s => s.PointOfSaleDTO.DistanceInMeters))
                .ForMember(d => d.Address, source => source.MapFrom(s => s.PointOfSaleDTO.Address))
                .ForMember(d => d.PromoCode, act => act.NullSubstitute("Not Available"));

            CreateMap<ConfigVariableDTO, ConfigVariable>()
                .ForMember(v => v.Id, source => source.MapFrom(s => s.ConfigId))
                .ForMember(v => v.Value, source => source.MapFrom(s => s.ConfigValue))
                .ForMember(v => v.Description, source => source.MapFrom(s => s.ConfigDescription))
                .ForMember(v => v.Name, source => source.MapFrom(s => s.ConfigName)); 

            CreateMap<ConfigVariable, ConfigVariableDTO>()
                .ForMember(v => v.ConfigId, source => source.MapFrom(s => s.Id))
                .ForMember(v => v.ConfigValue, source => source.MapFrom(s => s.Value))
                .ForMember(v => v.ConfigDescription, source => source.MapFrom(s => s.Description))
                .ForMember(v => v.ConfigName, source => source.MapFrom(s => s.Name));
        }
    }
}
