using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class car
    {
        private float mGasLimit=0;


        public float GasLimit {
            get {
                return mGasLimit;
            }

            set {
                if(value>100)
                    mGasLimit = 99;
                else
                    mGasLimit = value;
            }


        }
    }
}
