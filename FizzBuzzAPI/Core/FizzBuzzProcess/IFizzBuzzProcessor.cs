using System.Threading.Tasks;

namespace FizzBuzzAPI.Core
{
    public interface IFizzBuzzProcessor
    {
        
        string ProcessInput(int figure);
        Task<string> ProcessInputAsync(int figure);
    }
}