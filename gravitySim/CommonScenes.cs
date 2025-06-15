using MathsObjects;
using NewtonianSimulation;

//Common masses (kg):
//Mass Sun: 1.988416E+30
//Mass Earth: 5.972E+24
//Mass Moon: 7.348E+22
//Mass Mercury: 3.301E+23
//Mass Venus:  4.867E+24
//Mass Mars: 6.417E+23
//Mass Jupiter: 1.899E+27
//Mass Satrun: 5.685E+26
//Mass Uranus: 8.682E+25
//Mass Neptune: 1.024E+26

namespace Scenes
{
    public class CommonScenes
    {
        public static Scene sunEarth
        {
            get
            {

                CelestialObject sun = new CelestialObject(
                    1.988416E+30,
                    695700000,
                    new VectorCartesian(0, 0, 0),
                    new VectorCartesian(0, 0, 0)
                );

                CelestialObject earth = new CelestialObject(
                    5.972E+24,
                    6378000,
                    new VectorCartesian(0, 29800, 0),
                    new VectorCartesian(149597870700, 0, 0)
                );

                return new Scene(new List<CelestialObject> { sun, earth });
            }
        }


        public static Scene solarSystem
        {
            get
            {
                CelestialObject sun = new CelestialObject(
                    1.988416E+30,
                    695700000,
                    new VectorCartesian(0, 0, 0),
                    new VectorCartesian(0, 0, 0)
                );

                CelestialObject mercury = new CelestialObject(
                    3.301E+23,
                    2439500,
                    new VectorCartesian(0, 47400, 0),
                    new VectorCartesian(57.9E+9, 0, 0)
                );

                CelestialObject venus = new CelestialObject(
                    4.867E+24,
                    6052000,
                    new VectorCartesian(0, 35000, 0),
                    new VectorCartesian(108.2E+9, 0, 0)
                );

                CelestialObject earth = new CelestialObject(
                    5.972E+24,
                    6378000,
                    new VectorCartesian(0, 29800, 0),
                    new VectorCartesian(149597870700, 0, 0)
                );

                CelestialObject mars = new CelestialObject(
                    0.642E+24,
                    3396000,
                    new VectorCartesian(0, 24100, 0),
                    new VectorCartesian(228.2E+9, 0, 0)
                );

                CelestialObject jupiter = new CelestialObject(
                    1.899E+27,
                    71492000,
                    new VectorCartesian(0, 13100, 0),
                    new VectorCartesian(778.5E+9, 0, 0)
                );

                CelestialObject saturn = new CelestialObject(
                    5.685E+26,
                    120536000 / 2,
                    new VectorCartesian(0, 9700, 0),
                    new VectorCartesian(1432.05E+9, 0, 0)
                );

                CelestialObject uranus = new CelestialObject(
                    8.682E+25,
                    51118000 / 2,
                    new VectorCartesian(0, 6800, 0),
                    new VectorCartesian(2867.05E+9, 0, 0)
                );

                CelestialObject neptune = new CelestialObject(
                    1.024E+26,
                    49528000 / 2,
                    new VectorCartesian(0, 5400, 0),
                    new VectorCartesian(4515E+9, 0, 0)
                );

                return new Scene(new List<CelestialObject> { sun, mercury, venus, earth, mars, jupiter, saturn, uranus, neptune });
            }
        }

        public static Scene earthMoon
        {
            get
            {
                CelestialObject earth = new CelestialObject(
                    5.972E+24,
                    6378000,
                    new VectorCartesian(0, 0, 0),
                    new VectorCartesian(0, 0, 0)
                );

                CelestialObject moon = new CelestialObject(
                    7.348E+22,
                    3475000 / 2,
                    new VectorCartesian(0, 1000, 0),
                    new VectorCartesian(384500000, 0, 0)
                );

                return new Scene(new List<CelestialObject> { earth, moon });
            }
        }
    }
}