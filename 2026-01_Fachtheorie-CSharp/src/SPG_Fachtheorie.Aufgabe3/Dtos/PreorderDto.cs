namespace SPG_Fachtheorie.Aufgabe3.Dtos;

public record PreorderDto(DateTime PlacedAt, decimal TotalAmount, List<PreorderItemDto> PreorderItems);
