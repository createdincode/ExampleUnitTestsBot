using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ExampleUnitTestsBot.Helpers
{
    public interface IChatHelper
    {
        Task PostAsync(IDialogContext context, string message);
    }
    [Serializable]
    public class ChatHelper : IChatHelper
    {
        public async Task PostAsync(IDialogContext context, string message)
        {
            await context.PostAsync(message);
        }
    }
}