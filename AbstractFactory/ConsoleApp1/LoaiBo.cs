using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class LoaiBoFactory : MonAnFactory
    {
        public Pho LayToPho()
        {
            return new PhoBo();
        }

        public My LayToMy()
        {
            return new MyBo();
        }
    }
}
