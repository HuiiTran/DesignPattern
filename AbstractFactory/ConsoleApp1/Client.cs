using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Client
    {
        
            Pho pho;
            My my;

            public Client(MonAnFactory factory)
            {
                pho = factory.LayToPho();
                my = factory.LayToMy();
            }

            public string GetPhoDetails()
            {
                return pho.GetModelDetails();
            }

            public string GetMyDetails()
            {
                return my.GetModelDetails();
            }
        
    }
}
