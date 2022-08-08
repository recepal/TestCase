using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaka2
{
    public interface IRobot
    {
        int[] GetPos();
        DirectionEnum GetDir();
        void Step(int num);
    }
}
