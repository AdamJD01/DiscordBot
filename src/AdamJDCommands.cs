/*
    The commands class of the Discord Bot 
    
    The prefix for commands is "!"
    
    TODO:
    -Add all of the commands
*/

//the dependencies used
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class AdamJDCommands : BaseCommandModule //extends from the BaseCommandModule to register the commands in AdamJDBot.cs
    {
        //A test command, this is used just to make sure the bot is working and can receive commands
        [Command("test")] //the command name
        [Description("A test command")] //the command description
        
        public async Task Test(CommandContext commandContext) //set up the command channel
        {
            await commandContext.Channel.SendMessageAsync("test").ConfigureAwait(false); //output the result to Discord
            Console.WriteLine("The command 'test' is working"); //for debugging
        }

        //A command to add numbers, the user inputs two numbers and the bot adds them up
        [Command("add")] //the command name
        [Description("A command for adding numbers")] //the command description
        
        public async Task Add(CommandContext commandContext, float numberOne, float numberTwo) //set up the command channel and get the numbers
        {
            await commandContext.Channel.SendMessageAsync((numberOne + numberTwo).ToString()).ConfigureAwait(false); //output the result to Discord
            Console.WriteLine("The command 'add' is working"); //for debugging
        }

        //A command to subtract numbers, the user inputs two numbers and the bot subtracts them 
        [Command("subtract")] //the command name
        [Description("A command for subtracting numbers")] //the command description

        public async Task Subtract(CommandContext commandContext, float numberOne, float numberTwo) //set up the command channel and get the numbers
        {
            await commandContext.Channel.SendMessageAsync((numberOne - numberTwo).ToString()).ConfigureAwait(false); //output the result to Discord
            Console.WriteLine("The command 'subtract' is working"); //for debugging
        }

        //A command to multiply numbers, the user inputs two numbers and the bot multiplies them 
        [Command("multiply")] //the command name
        [Description("A command for multiplying numbers")] //the command description
        
        public async Task Multiply(CommandContext commandContext, float numberOne, float numberTwo) //set up the command channel and get the numbers
        {
            await commandContext.Channel.SendMessageAsync((numberOne * numberTwo).ToString()).ConfigureAwait(false); //output the result to Discord
            Console.WriteLine("The command 'multiply' is working"); //for debugging
        }

        //A command to divide numbers, the user inputs two numbers and the bot adds them up
        [Command("divide")] //the command name
        [Description("A command for adding numbers")] //the command description
       
        public async Task Divide(CommandContext commandContext, float numberOne, float numberTwo) //set up the command channel and get the numbers
        {
            await commandContext.Channel.SendMessageAsync((numberOne / numberTwo).ToString()).ConfigureAwait(false); //output the result to Discord
            Console.WriteLine("The command 'divide' is working"); //for debugging
        }

        //more fun commands will be added later!
    }
}
