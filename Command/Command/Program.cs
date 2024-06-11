


//interface command
interface ICommand
{
    void Execute();
    void Undo();
}


//invoker
class Remote
{
    private readonly ICommand turnOnCommand;
    private readonly ICommand turnOffCommand;

    public Remote(ICommand turnOnCommand, ICommand turnOffCommand)
    {
        this.turnOnCommand = turnOnCommand;
        this.turnOffCommand = turnOffCommand;
    }

    public void TurnOnButtonClick()
    {
        turnOnCommand.Execute();
    }

    public void TurnOffButtonClick()
    {
        turnOffCommand.Execute();
    }
}


//implement 2 commander from interface
class TurnOffCommand : ICommand
{
    private readonly Fan fan;

    public TurnOffCommand(Fan fan)
    {
        this.fan = fan;
    }

    public void Execute()
    {
        fan.TurnOff();
    }

    public void Undo()
    {
        fan.TurnOn();
    }
}

class TurnOnCommand : ICommand
{
    private readonly Fan fan;

    public TurnOnCommand(Fan fan)
    {
        this.fan = fan;
    }

    public void Execute()
    {
        fan.TurnOn();
    }

    public void Undo()
    {
        fan.TurnOff();
    }
}


//receiver
class Fan
{
    public void TurnOn()
    {
        Console.WriteLine("Turn on");
    }
    public void TurnOff()
    {
        Console.WriteLine("Turn off");
    }
}

//client
class Client
{
    static void Main(string[] args)
    {
        Fan fan = new Fan(); //receiver

        ICommand turnOnCommand = new TurnOnCommand(fan); //command1 
        ICommand turnOffCommand = new TurnOffCommand(fan);//command2 

        Remote remote = new Remote(turnOnCommand, turnOffCommand);//invoker

        remote.TurnOnButtonClick();
        remote.TurnOffButtonClick();
    }
}
