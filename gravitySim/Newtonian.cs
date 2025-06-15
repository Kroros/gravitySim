using System;
using System.Numerics;
using System.Reflection;
using MathsObjects;


namespace NewtonianSimulation
{
    public class Scene
    {
        public List<CelestialObject> Bodies { get; set; }
        public double G = 6.6743E-11; // Gravitational Constant
        public VectorCartesian Force(CelestialObject obj1, CelestialObject obj2)
        {
            if (obj1 == obj2)
            {
                return new VectorCartesian(0, 0, 0);
            }

            VectorCartesian pos1 = obj1.Position;
            VectorCartesian pos2 = obj2.Position;
            double m1 = obj1.Mass;
            double m2 = obj2.Mass;

            VectorCartesian direction = pos2 - pos1;
            double norm = direction.Norm();
            double force = G * m1 * m2 / (norm * norm);
            return force / norm * direction;
        }

        public Scene(List<CelestialObject> bodies)
        {
            Bodies = bodies;
        }

        public void UpdateScene(double stepSize)
        {
            double dt = stepSize * 31_536_000; //stepSize is in years, calculations are in seconds

            //Using Velocity Verlet Integration, follow the steps:

            foreach (var body in Bodies)
            {
                body.Position += dt * body.Velocity + 0.5 * dt * dt * body.Acceleration; //Step 1: Calculate x(t + dt) = x + v dt + 0.5 a dt^2
            }

            List<VectorCartesian> newAccs = Enumerable.Repeat(new VectorCartesian(0, 0, 0), Bodies.Count).ToList();



            for (int i = 0; i < Bodies.Count; i++)
            {
                for (int j = 0; j < Bodies.Count; j++)
                {
                    VectorCartesian force = Force(Bodies[i], Bodies[j]);
                    VectorCartesian acc = 1 / Bodies[i].Mass * force; //Step 2: Derive a(t+ dt) from the interaction potential using x(t+dt)

                    newAccs[i] += acc;
                }
            }

            for (int i = 0; i < Bodies.Count; i++)
            {
                Bodies[i].Velocity += 0.5 * dt * (Bodies[i].Acceleration + newAccs[i]); //Step 3: Calculate v(t+dt) = v + 0.5 ( a(t) + a(t + dt) ) dt
                Bodies[i].Acceleration = newAccs[i]; //Update Acceleration
            }
            //Congrats! You just carried out Velocity Verlet :D
        }

        public void RunSimNewton(double stepSize=0.00001, double runTime = 1, int logInterval = 1000)
        {
            double time = 0;
            int stepCount = 0;

            while (time < runTime)
            {
                UpdateScene(stepSize);
                time += stepSize;
                if (stepCount % 1000 == 0)
                {
                    Console.WriteLine($"{Bodies[1].Position.X},{Bodies[1].Position.Y},{Bodies[1].Position.Z}");
                }
                stepCount++;
            }
        }
    }
}