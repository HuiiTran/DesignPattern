using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class LoaiTronFactory : MonAnFactory
    {
        public Pho LayToPho()
        {
            return new PhoTron();
        }

        public My LayToMy()
        {
            return new MyTron();
        }
    }
}
