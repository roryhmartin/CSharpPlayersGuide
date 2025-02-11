namespace The_old_Robot_Interface;

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];

    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this); // 'this' refers to the current instance of the class in which it is used. The current robot that is executing the command. so if we made a new robot class called myRobot, 'this' would be myRobot when it is used in the myRobot class. 
                                    //If command is not null, call Run(), passing this (which is myRobot) as an argument.
           
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}