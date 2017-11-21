using UnityEngine;
using UnityEditor;

public enum Orientation 
{
    NORTH,
    SOUTH,
    EAST,
    WEST
}

public static class OrientationExt
{
    public static Orientation GetToLeft(this Orientation ori)
    {
        switch (ori)
        {
            case Orientation.NORTH:
                return Orientation.WEST;
            case Orientation.SOUTH:
                return Orientation.EAST;
            case Orientation.EAST:
                return Orientation.NORTH;
            case Orientation.WEST:
                return Orientation.SOUTH;
            default:
                return Orientation.NORTH;
        }
    }

    public static Orientation GetToRight(this Orientation ori)
    {
        switch (ori)
        {
            case Orientation.NORTH:
                return Orientation.EAST;
            case Orientation.SOUTH:
                return Orientation.WEST;
            case Orientation.EAST:
                return Orientation.SOUTH;
            case Orientation.WEST:
                return Orientation.NORTH;
            default:
                return Orientation.NORTH;
        }
    }
}
