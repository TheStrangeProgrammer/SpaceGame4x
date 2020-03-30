using System.Collections;
using System.Collections.Generic;
using System;

public class RandomUtility
{
    public static Random random;
    public RandomUtility(int seed)
    {
        if (seed == -1) {
            random = new Random(); 
        }
        else {
              random = new Random(seed);
        }
    }
    public RandomUtility()
    {
        random = new Random();
    }
}
