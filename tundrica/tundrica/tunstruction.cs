using System;
using System.Collections.Generic;
using System.Text;

namespace tundrica
{
    class tunstruction
    {
        interface tundrable
        {
            //string to_tundren_str();
        }
        interface yourlangable
        {
            string to_yourlang_str();
        }
        class progrix : tundrable
            /*program*/
        { }
        class clax : tundrable 
            /*class*/
        { }
        class fundrix : tundrable
        /*function*/
        { }
        class voidrix : tundrable
        /*procedure*/
        { }
        class rux : tundrable 
            /*pd byte - platform dependent byte*/
        { }
    }
}
