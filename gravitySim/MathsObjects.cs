namespace MathsObjects
{
    public class VectorCartesian
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public VectorCartesian(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public VectorSpherical ToSpherical()
        {
            double R = Math.Pow(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2), 0.5);
            double Inclination = Math.Acos(Z / R);
            double Azimuth;
            if (X > 0)
            {
                Azimuth = Math.Atan(Y / X);
            }
            else if (X < 0 && Y >= 0)
            {
                Azimuth = Math.Atan(Y / X) + Math.PI;
            }
            else if (X < 0 && Y < 0)
            {
                Azimuth = Math.Atan(Y / X) - Math.PI;
            }
            else if (X == 0 && Y > 0)
            {
                Azimuth = Math.PI / 2;
            }
            else if (X == 0 && Y < 0)
            {
                Azimuth = -Math.PI / 2;
            }
            else
            {
                Azimuth = 0;
            }

            return new VectorSpherical(R, Azimuth, Inclination);
        }

        public static VectorCartesian operator *(double scalar, VectorCartesian vec)
        {
            return new VectorCartesian(
                scalar * vec.X,
                scalar * vec.Y,
                scalar * vec.Z
            );
        }

        public static VectorCartesian operator +(VectorCartesian vec1, VectorCartesian vec2)
        {
            return new VectorCartesian(
                vec1.X + vec2.X,
                vec1.Y + vec2.Y,
                vec1.Z + vec2.Z
            );
        }

        public static VectorCartesian operator -(VectorCartesian vec1, VectorCartesian vec2)
        {
            return new VectorCartesian(
                vec1.X - vec2.X,
                vec1.Y - vec2.Y,
                vec1.Z - vec2.Z
            );
        }

        public static double operator *(VectorCartesian vec1, VectorCartesian vec2)
        {
            return vec1.X * vec2.X + vec1.Y * vec2.Y + vec1.Z * vec2.Z;
        }

        public double Norm(VectorCartesian vec)
        {
            return Math.Pow(vec * vec, 0.5);
        }
    }

    public class VectorSpherical
    {
        public double R { get; set; }
        public double Azimuth { get; set; }
        public double Inclination { get; set; }

        public VectorSpherical(double rad, double az, double inc)
        {
            R = rad;
            Azimuth = az;
            Inclination = inc;
        }

        public VectorCartesian ToCartesian()
        {
            double X = R * Math.Sin(Inclination) * Math.Cos(Azimuth);
            double Y = R * Math.Sin(Inclination) * Math.Sin(Azimuth);
            double Z = R * Math.Cos(Inclination);

            return new VectorCartesian(X, Y, Z);
        }

        public static VectorSpherical operator *(double scalar, VectorSpherical vec)
        {
            return new VectorSpherical(
                scalar * vec.R,
                vec.Azimuth,
                vec.Inclination
            );
        }
    }
    
    public class CelestialObject
    {
        public double Mass { get; set; }
        public double Radius { get; set; }
        public VectorCartesian Velocity { get; set; }
        public VectorCartesian Position { get; set; }

        public CelestialObject(double mass, double radius, VectorCartesian velocity, VectorCartesian position)
        {
            Mass = mass;
            Radius = radius;
            Velocity = velocity;
            Position = position;
        }
    }
}

