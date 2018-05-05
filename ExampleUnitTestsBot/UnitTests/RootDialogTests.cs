using ExampleUnitTestsBot.Dialogs;
using ExampleUnitTestsBot.Helpers;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ExampleUnitTestsBot.UnitTests
{
    [TestFixture]
    class RootDialogTests
    {
        private Mock<IChatHelper> _chat;
        private RootDialog _dialog;
        private Mock<IDialogContext> _context;

        [SetUp]
        public void SetUp()
        {
            _chat = new Mock<IChatHelper>();
            _dialog = new RootDialog(_chat.Object);
            _context = new Mock<IDialogContext>();
        }

        [Test]
        public async Task MessageReceivedAsync_ReceivesMessage_DisplaysTextAndLength()
        {
            var message = Activity.CreateMessageActivity();
            message.Text = "abc";

            await _dialog.MessageReceivedAsync(_context.Object, Awaitable.FromItem(message));

            _chat.Verify(c => c.PostAsync(_context.Object, "You sent abc which was 3 characters"));
        }
    }
}