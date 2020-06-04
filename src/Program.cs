namespace DiscordBot
{
    class Program
    {
        //call the bot
        static void Main(string[] args)
        {
            var discordBot = new AdamJDBot();
            discordBot.RunAsync().GetAwaiter().GetResult();
        }
    }
}
