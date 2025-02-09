namespace The_old_Robot_Interface;


public class OnCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}