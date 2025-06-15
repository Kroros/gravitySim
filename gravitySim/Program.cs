using MathsObjects;
using NewtonianSimulation;
using Scenes;

public class Simulation
{
    public static void Main(string[] args)
    {
        
        Scene solarSystem = CommonScenes.sunEarth;

        solarSystem.RunSimNewton();
    }
}