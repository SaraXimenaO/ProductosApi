namespace Products.Domain.Dtos;

public record ProductDto(
    int? ProductId, 
    string Name, 
    string StatusName, 
    int Stock, 
    string Description, 
    decimal Price, 
    int Discount, 
    decimal 
    FinalPrice 
    );
