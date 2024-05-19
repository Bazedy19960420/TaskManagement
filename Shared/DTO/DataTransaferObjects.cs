namespace Shared.DTO
{
    public record TaskDto
    (
        string Title,
        string Description,
        string DueDate,
        bool IsCompleted
    );

}
