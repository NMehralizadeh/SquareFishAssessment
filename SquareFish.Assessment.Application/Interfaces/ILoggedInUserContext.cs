
namespace SquareFish.Assessment.Application.Interfaces
{
    public interface ILoggedInUserContext
    {
        int Id { get; }
        string Name { get; }
        bool IsAuthenticated { get; }
    }
}
