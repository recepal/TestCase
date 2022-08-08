using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaka2
{
    public class Robot : IRobot
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public DirectionEnum Direction { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }
        public int StepCount { get; set; }

        public Robot(int height, int width)
        {
            if (width < 2 || height > 100) throw new Exception();

            Height = height;
            Width = width;
            Direction = DirectionEnum.Dogu;
            Latitude = 0;
            Longitude = 0;
            StepCount = 0;
        }

        public int[] GetPos()
        {
            int[] result = new[] { Latitude, Longitude };

            return result;
        }

        public DirectionEnum GetDir()
        {
            return Direction;
        }

        public void Step(int num)
        {
            if (num > 100000) throw new Exception();

            int xArea = Height - 1;
            int yArea = Width - 1;

            if (Direction == DirectionEnum.Dogu)
            {
                int newLatitude = Latitude += num;

                if (newLatitude <= xArea)
                {
                    Latitude = newLatitude;
                }
                else if (newLatitude > xArea)
                {
                    Latitude += xArea - Latitude;
                    Turn();
                    Step(newLatitude - xArea);
                }
            }
            else if (Direction == DirectionEnum.Bati)
            {
                int newLatitude = Latitude -= num;

                if (newLatitude >= 0)
                {
                    Latitude = newLatitude;
                }
                else if (newLatitude < 0)
                {
                    Latitude += Latitude;
                    Turn();
                    Step(newLatitude);
                }
            }
            else if (Direction == DirectionEnum.Kuzey)
            {
                int newLongitude = Longitude += num;

                if (newLongitude <= yArea)
                {
                    Longitude = newLongitude;
                }
                else if (newLongitude > yArea)
                {
                    Longitude += yArea - Latitude;
                    Turn();
                    Step(newLongitude - yArea);
                }
            }
            else if (Direction == DirectionEnum.Guney)
            {
                int newLongitude = Longitude -= num;

                if (newLongitude >= 0)
                {
                    Longitude = newLongitude;
                }
                else if (newLongitude < 0)
                {
                    Longitude += Longitude;
                    Turn();
                    Step(newLongitude);
                }
            }
        }

        public void Turn()
        {
            switch (Direction)
            {
                case DirectionEnum.Dogu:
                    Direction = DirectionEnum.Kuzey;
                    break;
                case DirectionEnum.Bati:
                    Direction = DirectionEnum.Guney;
                    break;
                case DirectionEnum.Kuzey:
                    Direction = DirectionEnum.Bati;
                    break;
                case DirectionEnum.Guney:
                    Direction = DirectionEnum.Dogu;
                    break;
                default:
                    break;
            }
        }
    }
}

// Robot oluştururur
// Adım için ilk önce adım atacak koordinat kontrolü yapılır,  x koordinatını dolana kadar yürür, sonra y koordinatını dolana kadar yürür,
//ikisi de dolmuş ise -x yönünde ilerler, -x de nötr hale geldiğinde -y yönünde ilerler.