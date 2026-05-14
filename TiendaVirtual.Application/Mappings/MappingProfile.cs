using AutoMapper;
using TiendaVirtual.Application.DTOs.Cart;
using TiendaVirtual.Application.DTOs.Order;
using TiendaVirtual.Application.DTOs.Product;
using TiendaVirtual.Application.DTOs.User;
using TiendaVirtual.Domain.Entities;
using TiendaVirtual.Application.DTOs.Category;

namespace TiendaVirtual.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Product
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.CategoryName,
                       opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.MinPlayers,
                       opt => opt.MapFrom(src => src.BoardGame != null ? src.BoardGame.MinPlayers : null))
            .ForMember(dest => dest.MaxPlayers,
                       opt => opt.MapFrom(src => src.BoardGame != null ? src.BoardGame.MaxPlayers : null))
            .ForMember(dest => dest.AvgDuration,
                       opt => opt.MapFrom(src => src.BoardGame != null ? src.BoardGame.AvgDuration : null))
            .ForMember(dest => dest.MinAge,
                       opt => opt.MapFrom(src => src.BoardGame != null ? src.BoardGame.MinAge : null))
            .ForMember(dest => dest.BoardGameType,
                       opt => opt.MapFrom(src => src.BoardGame != null ? src.BoardGame.Type : null))
            .ForMember(dest => dest.Platform,
                       opt => opt.MapFrom(src => src.VideoGame != null ? src.VideoGame.Platform : null))
            .ForMember(dest => dest.Developer,
                       opt => opt.MapFrom(src => src.VideoGame != null ? src.VideoGame.Developer : null))
            .ForMember(dest => dest.Pegi,
                       opt => opt.MapFrom(src => src.VideoGame != null ? src.VideoGame.Pegi : null))
            .ForMember(dest => dest.Author,
                       opt => opt.MapFrom(src => src.Book != null ? src.Book.Author : null))
            .ForMember(dest => dest.Publisher,
                       opt => opt.MapFrom(src => src.Book != null ? src.Book.Publisher : null))
            .ForMember(dest => dest.ISBN,
                       opt => opt.MapFrom(src => src.Book != null ? src.Book.ISBN : null))
            .ForMember(dest => dest.Pages,
                       opt => opt.MapFrom(src => src.Book != null ? src.Book.Pages : null))
            .ForMember(dest => dest.Language,
                       opt => opt.MapFrom(src => src.Book != null ? src.Book.Language : null))
            .ForMember(dest => dest.CollectibleType,
                       opt => opt.MapFrom(src => src.Collectible != null ? src.Collectible.Type : null))
            .ForMember(dest => dest.Material,
                       opt => opt.MapFrom(src => src.Collectible != null ? src.Collectible.Material : null))
            .ForMember(dest => dest.LimitedEdition,
                       opt => opt.MapFrom(src => src.Collectible != null ? src.Collectible.LimitedEdition : (bool?)null))
            .ForMember(dest => dest.Size,
                       opt => opt.MapFrom(src => src.Collectible != null ? src.Collectible.Size : null))
            .ForMember(dest => dest.Reference,
                       opt => opt.MapFrom(src => src.Collectible != null ? src.Collectible.Reference : null))
            .ForMember(dest => dest.Pieces,
                       opt => opt.MapFrom(src => src.Puzzle != null ? src.Puzzle.Pieces : null))
            .ForMember(dest => dest.Difficulty,
                       opt => opt.MapFrom(src => src.Puzzle != null ? src.Puzzle.Difficulty : null))
            .ForMember(dest => dest.Shape,
                       opt => opt.MapFrom(src => src.Puzzle != null ? src.Puzzle.Shape : null))
            .ForMember(dest => dest.Creator,
                       opt => opt.MapFrom(src => src.Puzzle != null ? src.Puzzle.Creator : null))
            .ForMember(dest => dest.Dimensions,
                       opt => opt.MapFrom(src => src.Puzzle != null ? src.Puzzle.Dimensions : null))
            .ForMember(dest => dest.Images,
                       opt => opt.MapFrom(src => src.Images ?? new List<ProductImage>()));


        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>();

        // BoardGame
        CreateMap<Product, BoardGameDto>()
            .ForMember(dest => dest.CategoryName,
                       opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.MinPlayers,
                       opt => opt.MapFrom(src => src.BoardGame != null ? src.BoardGame.MinPlayers : null))
            .ForMember(dest => dest.MaxPlayers,
                       opt => opt.MapFrom(src => src.BoardGame != null ? src.BoardGame.MaxPlayers : null))
            .ForMember(dest => dest.AvgDuration,
                       opt => opt.MapFrom(src => src.BoardGame != null ? src.BoardGame.AvgDuration : null))
            .ForMember(dest => dest.MinAge,
                       opt => opt.MapFrom(src => src.BoardGame != null ? src.BoardGame.MinAge : null))
            .ForMember(dest => dest.Type,
                       opt => opt.MapFrom(src => src.BoardGame != null ? src.BoardGame.Type : null));

        // User
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.RoleName,
                       opt => opt.MapFrom(src => src.Role.Name));

        // Cart
        CreateMap<Cart, CartItemDto>()
            .ForMember(dest => dest.ProductName,
                       opt => opt.MapFrom(src => src.Product.Name))
            .ForMember(dest => dest.Price,
                       opt => opt.MapFrom(src => src.Product.Price));

        // Order
        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.UserName,
                       opt => opt.MapFrom(src => src.User.Name + " " + src.User.Surname))
            .ForMember(dest => dest.Lines,
                       opt => opt.MapFrom(src => src.OrderLines));
        CreateMap<OrderLine, OrderLineDto>()
            .ForMember(dest => dest.ProductName,
                       opt => opt.MapFrom(src => src.Product.Name));

        // VideoGame
        CreateMap<Product, VideoGameDto>()
            .ForMember(dest => dest.CategoryName,
                       opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.Platform,
                       opt => opt.MapFrom(src => src.VideoGame != null ? src.VideoGame.Platform : null))
            .ForMember(dest => dest.Developer,
                       opt => opt.MapFrom(src => src.VideoGame != null ? src.VideoGame.Developer : null))
            .ForMember(dest => dest.Pegi,
                       opt => opt.MapFrom(src => src.VideoGame != null ? src.VideoGame.Pegi : null));

        // Book
        CreateMap<Product, BookDto>()
            .ForMember(dest => dest.CategoryName,
                       opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.Author,
                       opt => opt.MapFrom(src => src.Book != null ? src.Book.Author : null))
            .ForMember(dest => dest.Publisher,
                       opt => opt.MapFrom(src => src.Book != null ? src.Book.Publisher : null))
            .ForMember(dest => dest.ISBN,
                       opt => opt.MapFrom(src => src.Book != null ? src.Book.ISBN : null))
            .ForMember(dest => dest.Pages,
                       opt => opt.MapFrom(src => src.Book != null ? src.Book.Pages : null))
            .ForMember(dest => dest.Language,
                       opt => opt.MapFrom(src => src.Book != null ? src.Book.Language : null));

        // Collectible
        CreateMap<Product, CollectibleDto>()
            .ForMember(dest => dest.CategoryName,
                       opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.Type,
                       opt => opt.MapFrom(src => src.Collectible != null ? src.Collectible.Type : null))
            .ForMember(dest => dest.Material,
                       opt => opt.MapFrom(src => src.Collectible != null ? src.Collectible.Material : null))
            .ForMember(dest => dest.LimitedEdition,
                       opt => opt.MapFrom(src => src.Collectible != null && src.Collectible.LimitedEdition))
            .ForMember(dest => dest.Size,
                       opt => opt.MapFrom(src => src.Collectible != null ? src.Collectible.Size : null))
            .ForMember(dest => dest.Reference,
                       opt => opt.MapFrom(src => src.Collectible != null ? src.Collectible.Reference : null));

        // Puzzle
        CreateMap<Product, PuzzleDto>()
            .ForMember(dest => dest.CategoryName,
                       opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.Pieces,
                       opt => opt.MapFrom(src => src.Puzzle != null ? src.Puzzle.Pieces : null))
            .ForMember(dest => dest.Difficulty,
                       opt => opt.MapFrom(src => src.Puzzle != null ? src.Puzzle.Difficulty : null))
            .ForMember(dest => dest.Shape,
                       opt => opt.MapFrom(src => src.Puzzle != null ? src.Puzzle.Shape : null))
            .ForMember(dest => dest.Material,
                       opt => opt.MapFrom(src => src.Puzzle != null ? src.Puzzle.Material : null))
            .ForMember(dest => dest.MinAge,
                       opt => opt.MapFrom(src => src.Puzzle != null ? src.Puzzle.MinAge : null))
            .ForMember(dest => dest.Creator,
                       opt => opt.MapFrom(src => src.Puzzle != null ? src.Puzzle.Creator : null))
            .ForMember(dest => dest.Dimensions,
                       opt => opt.MapFrom(src => src.Puzzle != null ? src.Puzzle.Dimensions : null));

        CreateMap<TiendaVirtual.Domain.Entities.Category, CategoryDto>();
        // ProductImage
        CreateMap<ProductImage, ProductImageDto>();
    }
}