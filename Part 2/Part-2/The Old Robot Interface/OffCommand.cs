namespace The_old_Robot_Interface;


public class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}