using System;
using Vaka2;

public class Program
{
    public static void Main()
    {
        Robot robot = new Robot(6,3);
        robot.Step(2);
        robot.Step(2);
        robot.GetPos();
        robot.GetDir();
        robot.Step(2);
        robot.Step(1);
        robot.GetPos();
        robot.GetDir();
    }
}