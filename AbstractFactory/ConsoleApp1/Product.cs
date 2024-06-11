using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Product
    {
    }
    class PhoTron : Pho
    {
        public string GetModelDetails()
        {
            return "Pho TRON cua ban day";
        }
    }

    class PhoBo : Pho
    {
        public string GetModelDetails()
        {
            return "Pho BO cua ban day";
        }
    }

    class MyTron : My
    {
        public string GetModelDetails()
        {
            return "MY TRON cua ban day";
        }
    }

    class MyBo : My
    {
        public string GetModelDetails()
        {
            return "MY BO cua ban day";
        }
    }

}
