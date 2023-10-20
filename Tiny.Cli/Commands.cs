namespace Tiny.Cli;

public class Commands
{
   public string? HelpMessage { get; private set; }
   
   public string? SingleFile { get; private set; }

   private Commands() { }
    
    public static Commands? Create(string? helpMessage, string? singleFile)
    {
        return new Commands { 
            HelpMessage = helpMessage,
            SingleFile = singleFile
        };
    }
}