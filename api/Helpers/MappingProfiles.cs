using api.DTOs;
using api.DTOs.CustomerDTO;
using api.DTOs.IngredientDTO;
using api.DTOs.Orders;
using api.DTOs.ProductDTO;
using api.DTOs.SupplierDTO;
using AutoMapper;
using Core.Entities;
using Core.Entities.Orders;
using Core.Entities.Purchases;

namespace api.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, GetCustomerByIdDTO>();
            CreateMap<Address, AddressDTO>();
            CreateMap<Order, OrderSumDTO>();

            CreateMap<PostCustomerDTO, Customer>()
                .ForMember(dest => dest.DeliveryAddress, opt => opt.MapFrom(src => src.DeliveryAddress))
                .ForMember(dest => dest.InvoiceAddress, opt => opt.MapFrom(src => src.InvoiceAddress));
            CreateMap<AddressDTO, Address>();

            CreateMap<Ingredient, GetIngredientDTO>()
                .ForMember(d => d.Suppliers, o => o.MapFrom(s => s.SupplierIngredients));

            CreateMap<SupplierIngredient, SupplierIngredientDTO>()
                .ForMember(d => d.IngredientName, o => o.MapFrom(s => s.Ingredient.IngredientName))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Supplier.Email))
                .ForMember(d => d.PricePerKg, o => o.MapFrom(s => s.PricePerKg));


            CreateMap<Product, GetProductDTO>();
            CreateMap<PostProductDTO, Product>();
            CreateMap<PatchProductDTO, Product>();

            CreateMap<OrderItem, GetOrderItemDTO>()
                .ForMember(d => d.ProductName, m => m.MapFrom(s => s.ItemOrdered.ProductName));

            CreateMap<Order, GetOrdersDTO>()
                .ForMember(d => d.CustomerName, m => m.MapFrom(s => s.Customer.CompanyName))
                .ForMember(d => d.Items, m => m.MapFrom(s => s.OrderItems))
                .ForMember(d => d.SubTotal, m => m.MapFrom(s => s.SubTotal));

            CreateMap<PostSupplierDTO, Supplier>();

            CreateMap<Supplier, GetSupplierDTO>();

            CreateMap<Supplier, GetSupplierWithIngredientsDTO>()
                .ForMember(d => d.Ingredients, o => o.MapFrom(s => s.SupplierIngredients));

            CreateMap<SupplierIngredient, SupplierIngredientDTO>()
                .ForMember(d => d.IngredientName, o => o.MapFrom(s => s.Ingredient.IngredientName));


        }
    }
}