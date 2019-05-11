using System;
using System.Collections;
using System.Collections.Generic;

public class ShapeInfo
{
    private static string[] tags = 
    {"diamondPrism",
     "trianglePrism",
     "cube",
     "cylinder"};


    public static List<string> getShapeTags()
    {
        return new List<string>(tags);
    }
}
