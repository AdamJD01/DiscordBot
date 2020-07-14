/*
    The commands class of the Discord Bot 
    
    The prefix for commands is "!"
    
    TODO:
    -Include more facts for the 'fact' command
    -Add all of the commands
*/

//the dependencies used
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class AdamJDCommands : AdamJDBot 
    {
        /*
        //A test command, this is used just to make sure the bot is working and can receive commands
        [Command("test")] //the command name
        [Description("A test command")] //the command description
        //
        public async Task Test(CommandContext commandContext) //set up the command channel
        {
            await commandContext.Channel.SendMessageAsync("test").ConfigureAwait(false); //output the result to Discord
            
            //for debugging the command
            if(Task.CompletedTask.IsCompletedSuccessfully)
            {   
                Console.WriteLine("The command 'test' IS working"); 
            }
            else
            {
                Console.WriteLine("The command 'test' IS NOT working"); 
            }
        }
        */

        //A command to add numbers, the user inputs two numbers and the bot adds them
        [Command("add")] //the command name
        [Description("A command for adding numbers")] //the command description
        //
        public async Task Add(CommandContext commandContext, float numberOne, float numberTwo) //set up the command channel and get the numbers
        {
            await commandContext.Channel.SendMessageAsync((numberOne + numberTwo).ToString()).ConfigureAwait(false); //output the result to Discord

            /*
            //for debugging the command
            if(Task.CompletedTask.IsCompletedSuccessfully)
            {
                Console.WriteLine("The command 'add' IS working");
            }
            else
            {
                Console.WriteLine("The command 'add' IS NOT working");
            }
            */
        }

        //A command to subtract numbers, the user inputs two numbers and the bot subtracts them 
        [Command("subtract")] //the command name
        [Description("A command for subtracting numbers")] //the command description
        //
        public async Task Subtract(CommandContext commandContext, float numberOne, float numberTwo) //set up the command channel and get the numbers
        {
            await commandContext.Channel.SendMessageAsync((numberOne - numberTwo).ToString()).ConfigureAwait(false); //output the result to Discord

            /*
            //for debugging the command
            if(Task.CompletedTask.IsCompletedSuccessfully)
            {
                Console.WriteLine("The command 'subtract' IS working");
            }
            else
            {
                Console.WriteLine("The command 'subtract' IS NOT working");
            }
            */
        }

        //A command to multiply numbers, the user inputs two numbers and the bot multiplies them 
        [Command("multiply")] //the command name
        [Description("A command for multiplying numbers")] //the command description
        //
        public async Task Multiply(CommandContext commandContext, float numberOne, float numberTwo) //set up the command channel and get the numbers
        {
            await commandContext.Channel.SendMessageAsync((numberOne * numberTwo).ToString()).ConfigureAwait(false); //output the result to Discord

            /*
            //for debugging the command
            if(Task.CompletedTask.IsCompletedSuccessfully)
            {
                Console.WriteLine("The command 'multiply' IS working");
            }
            else
            {
                Console.WriteLine("The command 'multiply' IS NOT working");
            }
            */
        }

        //A command to divide numbers, the user inputs two numbers and the bot divides them
        [Command("divide")] //the command name
        [Description("A command for dividing numbers")] //the command description
        //
        public async Task Divide(CommandContext commandContext, float numberOne, float numberTwo) //set up the command channel and get the numbers
        {
            await commandContext.Channel.SendMessageAsync((numberOne / numberTwo).ToString()).ConfigureAwait(false); //output the result to Discord

            /*
            //for debugging the command
            if(Task.CompletedTask.IsCompletedSuccessfully)
            {
                Console.WriteLine("The command 'divide' IS working");
            }
            else
            {
                Console.WriteLine("The command 'divide' IS NOT working");
            }
            */
        }

        //A command that displays a random fact, the user just needs to use the command and a random fact will appear
        [Command("fact")] //the command name
        [Description("A command for showing a random fact")] //the command description
        //
        public async Task RandomFact(CommandContext commandContext) //set up the command channel
        {
            //the fact strings
            string[] Facts =
            {
                "Henry VIII slept with a big axe next to him",
                "Bullfrogs don't sleep",
                "The microwave was invented by mistake",
                "The first computer mouse was made of wood in 1964",
                "Only humans can cry when upset",
            };
            
            //make the fact random and set up the output string
            string FactToShow;
            FactToShow = Facts[new Random().Next(0, Facts.Length)];

            await commandContext.Channel.SendMessageAsync(FactToShow.ToString()).ConfigureAwait(false); //output the result to Discord

            /*
            //for debugging the command
            if(Task.CompletedTask.IsCompletedSuccessfully)
            {
                Console.WriteLine("The command 'fact' IS working");
            }
            else
            {
                Console.WriteLine("The command 'fact' IS NOT working");
            }
            */
        }

        //A command that generates two random numbers, both the user and the bot have a number generated at random between 0-12 and whoever is the closest wins
        [Command("randomNumbers")] //the command name
        [Description("A command for generating two random numbers and comparing them")] //the command description
        //
        public async Task RandomNumbers(CommandContext commandContext)
        {
            //the number arrays
            var userRandomNumber = new[] {1,2,3,4,5,6,7,8,9,10,11,12};
            var botRandomNumber = new[] {1,2,3,4,5,6,7,8,9,10,11,12};

            //the random numbers to show
            int userRandomNumberToShow = userRandomNumber[new Random().Next(0, userRandomNumber.Length)];
            int botRandomNumberToShow = botRandomNumber[new Random().Next(0, botRandomNumber.Length)];

            //the string that shows the numbers to the user
            string FinalNumbersToShow = "Your number is " + userRandomNumberToShow.ToString() + " and my random number is " + botRandomNumberToShow.ToString();

            //the string that determines if the user has won, the bot has won or if it is a draw
            string Outcome = "";

            if (userRandomNumberToShow > botRandomNumberToShow)
            {
                Outcome = "You have a higher number than me so you win";
            }

            else if (botRandomNumberToShow > userRandomNumberToShow)
            {
                Outcome = "You have a lower number than me so you lose";
            }

            else if (userRandomNumberToShow == botRandomNumberToShow)
            {
                Outcome = "You have the same number as me so it's a draw";
            }

            //output the result to Discord
            await commandContext.Channel.SendMessageAsync(FinalNumbersToShow.ToString()).ConfigureAwait(false); 
            await commandContext.Channel.SendMessageAsync(Outcome.ToString()).ConfigureAwait(false);
        }
    }
}
