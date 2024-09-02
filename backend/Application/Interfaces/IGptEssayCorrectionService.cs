using backend.Models;

namespace backend.Application.Interfaces
{
    public interface IGptEssayCorrectionService
    {
        IAsyncEnumerable<string> CorrectEssayAsync(EssayTextInput input);
    }
}