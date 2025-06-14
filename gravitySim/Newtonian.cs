using System;
using System.Numerics;
using MathsObjects;

namespace NewtonianSimulation;

public class NewtonianSim
{
    public static void Main(string[] args)
    {
        CelestialObject earth = new CelestialObject(5.972E+24, 6378, new VectorSpherical(0, 2 * Math.PI / 31536000, 0).ToCartesian(), new VectorSpherical(149597870700, 0, 0).ToCartesian());
        CelestialObject sun = new CelestialObject(1.988416E+30, 695700, new VectorCartesian(0, 0, 0), new VectorCartesian(0, 0, 0));
        Scene solarSystem = new Scene(new List<CelestialObject> { earth, sun });
    }
}

public class Scene
{
    public List<CelestialObject> Bodies{ get; set; }
    public double G = 6.6743E-11;
    public VectorCartesian Force(VectorCartesian pos1, VectorCartesian pos2, double m1, double m2)
    {
        double dist2 = (pos2 - pos1).Norm(pos2 - pos1);
        VectorCartesian direction = pos2 - pos1;
        double norm = direction.Norm(direction);
        double force = G * m1 * m2 / dist2;
        return force / norm * direction;
    }

    public Scene(List<CelestialObject> bodies)
    {
        Bodies = bodies;
    }

    public void UpdateScene()
    {
    }
}