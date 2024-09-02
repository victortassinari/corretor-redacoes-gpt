using backend.Application.Interfaces;
using backend.Models;
using OpenAI.Chat;
using System.ClientModel;

namespace backend.Application.Services;

public class GptEssayCorrectionService : IGptEssayCorrectionService
{
    private readonly string _systemPrompt;
    private readonly IConfiguration _configuration;

    public GptEssayCorrectionService(IConfiguration configuration)
    {
        _systemPrompt = File.ReadAllText("Content/SystemPrompt.txt");
        _configuration = configuration;
    }

    public async IAsyncEnumerable<string> CorrectEssayAsync(EssayTextInput input)
    {
        ChatClient client = new(model: "gpt-4o", _configuration.GetValue<string>("OPENAI_API_KEY"));

        AsyncCollectionResult<StreamingChatCompletionUpdate> updates = client.CompleteChatStreamingAsync([
                           new SystemChatMessage(_systemPrompt),
                           new UserChatMessage("Retorne o texto corrigido abaixo com as correções e notas explicativas."),
                           new UserChatMessage("Tema: ",input.Theme),
                           new UserChatMessage("Título: ", input.Title),
                           new UserChatMessage("Redação: ",input.Text),
                           ]);

        await foreach (StreamingChatCompletionUpdate update in updates)
        {
            foreach (ChatMessageContentPart updatePart in update.ContentUpdate)
            {
                yield return updatePart.Text;
            }
        }
    }
}