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
            
            CreateMap<Customer, GetCustomerDTO>();
            CreateMap<Customer, GetCustomerByIdDTO>()
                .ForMember(d => d.Orders, o => o.MapFrom(s => s.Orders));

            CreateMap<Address, AddressDTO>();
            CreateMap<AddressDTO, Address>();

            CreateMap<PostCustomerDTO, Customer>()
                .ForMember(d => d.DeliveryAddress, o => o.MapFrom(s => s.DeliveryAddress))
                .ForMember(d => d.InvoiceAddress, o => o.MapFrom(s => s.InvoiceAddress));

            CreateMap<PatchCustomerDTO, Customer>();


            
            CreateMap<Ingredient, GetIngredientDTO>()
                .ForMember(d => d.Suppliers, o => o.MapFrom(s => s.SupplierIngredients));

            CreateMap<PostIngredientDTO, Ingredient>();
            CreateMap<PutIngredientDTO, Ingredient>();

            
            CreateMap<SupplierIngredient, SupplierIngredientDTO>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.SupplierId))
                .ForMember(d => d.SupplierName, o => o.MapFrom(s => s.Supplier.SupplierName))
                .ForMember(d => d.IngredientId, o => o.MapFrom(s => s.IngredientId))
                .ForMember(d => d.IngredientName, o => o.MapFrom(s => s.Ingredient.IngredientName))
                .ForMember(d => d.PricePerKg, o => o.MapFrom(s => s.PricePerKg));


            
            CreateMap<PostSupplierDTO, Supplier>();
            CreateMap<Supplier, GetSupplierDTO>();

            CreateMap<Supplier, GetSupplierWithIngredientsDTO>()
                .ForMember(d => d.Ingredients, o => o.MapFrom(s => s.SupplierIngredients));


            
            CreateMap<Product, GetProductDTO>();
            CreateMap<PostProductDTO, Product>();
            CreateMap<PatchProductDTO, Product>();


            
            CreateMap<OrderItem, GetOrderItemDTO>()
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
                .ForMember(d => d.Price, o => o.MapFrom(s => s.Price))
                .ForMember(d => d.Quantity, o => o.MapFrom(s => s.Quantity))
                .ForMember(d => d.SubTotal, o => o.MapFrom(s => s.Price * s.Quantity));


            
            CreateMap<Order, GetOrdersDTO>()
                .ForMember(d => d.CustomerName, o => o.MapFrom(s => s.Customer.CompanyName))
                .ForMember(d => d.CustomerContact, o => o.MapFrom(s => s.Customer.ContactPerson))
                .ForMember(d => d.CustomerEmail, o => o.MapFrom(s => s.Customer.Email))
                .ForMember(d => d.Items, o => o.MapFrom(s => s.OrderItems))
                .ForMember(d => d.SubTotal, o => o.MapFrom(s => s.SubTotal));
        }
    }
}