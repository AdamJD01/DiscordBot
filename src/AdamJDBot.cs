/*
    The base class of the Discord Bot 
        
    TODO:
    -Include a logo/image
    -Implement extra features
*/

//the dependencies used
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Newtonsoft.Json;

namespace DiscordBot
{
    public class AdamJDBot 
    {
        //set up the DiscordClient
        public DiscordClient Client
        {
            get;
            private set;
        }

        //set up the commands
        public CommandsNextExtension Commands
        {
            get;
            private set;
        }
       
        public async Task RunAsync()
        {
            //get a connection to Discord
            var json = string.Empty;
            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
            json = await sr.ReadToEndAsync().ConfigureAwait(false);

            var configToken = JsonConvert.DeserializeObject<ConfigJSONTokenPrefix>(json); //make the JSON file readable
            
            //configuration settings for the bot
            var config = new DiscordConfiguration
            {
                Token = configToken.Token, //get the token string
                TokenType = TokenType.Bot, //set the token type for a bot
                AutoReconnect = true, //autoreconnect the bot 
                LogLevel = LogLevel.Debug, //output debug messages to a console
                UseInternalLogHandler = true //use the internal log handler for debug messages
            };

            //apply the config settings
            Client = new DiscordClient(config);
            Client.Ready += IsReady;

            //command settings for the bot
            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[]
                {
                    configToken.Prefix //get the prefix string (!)
                },
                EnableMentionPrefix = true, //make the bot read the prefix
                EnableDms = false, //turn off the bot responding to DMs 
                CaseSensitive = false, //ignore the case type of commands
            };

            //apply the command settings
            Commands = Client.UseCommandsNext(commandsConfig);

            Commands.RegisterCommands<AdamJDCommands>(); //register the commands to the bot
            
            await Client.ConnectAsync(); //sync bot to the settings 
            await Task.Delay(-1); //make the bot "listen" for commands every second
        }

        //return task when ready
        private Task IsReady(ReadyEventArgs readyEvent)
        {
            return Task.CompletedTask;
        }
    }
}
