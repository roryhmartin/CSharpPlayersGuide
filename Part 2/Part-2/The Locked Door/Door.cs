using The_Locked_Door.enumerations;

namespace The_Locked_Door;

public class Door
{
    public DoorStateEnum DoorState { get; set; }
    static string Passcode { get; set; } = "yolo";
    
    public Door(DoorStateEnum doorState, string passcode)
    {
        DoorState = doorState;
        Passcode = passcode;
    }

    public void Open()
    {
        if (DoorState == DoorStateEnum.Closed || DoorState == DoorStateEnum.Unlocked)
        {
            DoorState = DoorStateEnum.Open;
            Console.WriteLine($"Door is now {DoorState}");
        }
        else
        {
            Console.WriteLine($"Door is {DoorState} and cannot be opened");
        }
    }
    
    public void Close()
    {
        if(DoorState == DoorStateEnum.Open)
        {
            DoorState = DoorStateEnum.Closed;
            Console.WriteLine($"Door is now {DoorState}");
        }
        else
        {
            Console.WriteLine($" Error: Door is {DoorState}");
        }
    }
    
    public void Lock(string passcode)
    {
        if (DoorState == DoorStateEnum.Closed)
        {
            if (PasscodeChecker(passcode))
            {
                Console.WriteLine("Door Locked");
                DoorState = DoorStateEnum.Locked;
            }
            else
            {
                Console.WriteLine("Incorrect Passcode");
            }
        }
        else
        {
            Console.WriteLine($"Door is {DoorState} and cannot be locked");
        }
    }
    
    public void Unlock(string passcode)
    {
        if (DoorState == DoorStateEnum.Locked)
        {
            if (PasscodeChecker(passcode))
            {
                Console.WriteLine("Door Unlocked");
                DoorState = DoorStateEnum.Unlocked;
            }
            else
            {
                Console.WriteLine("Incorrect Passcode");
            }
        }
    }
    
    private bool PasscodeChecker(string passcode)
    {
        return passcode == Passcode;
    }

    public static void SetPassCode(string passcode)
    {
        Passcode = passcode;
    }
}