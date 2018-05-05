using System;
using System.Threading.Tasks;
using ExampleUnitTestsBot.Helpers;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace ExampleUnitTestsBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        private IChatHelper _chat;

        public RootDialog(IChatHelper chat)
        {
            _chat = chat;
        }

        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
            return Task.CompletedTask;
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var message = await result as Activity;

            int length = (message.Text ?? string.Empty).Length;

            await _chat.PostAsync(context, $"You sent {message.Text} which was {length} characters");

            context.Wait(MessageReceivedAsync);
        }
    }
}