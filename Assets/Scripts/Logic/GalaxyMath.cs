using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GalaxyMath { 
    
}
public struct CartezianLine
{
    public readonly CartezianPosition pointA;
    public readonly CartezianPosition pointB;
    public CartezianLine(CartezianPosition pointA, CartezianPosition pointB)
    {
        this.pointA = pointA;
        this.pointB = pointB;
    }
    public static bool IsAngleLessThan(CartezianLine line1, CartezianLine line2, float minAngle)
    {
        double theta1 = Math.Atan2(line1.pointA.y - line1.pointB.y, line1.pointA.x - line1.pointB.x);
        double theta2 = Math.Atan2(line2.pointA.y - line2.pointB.y, line2.pointA.x - line2.pointB.x);
        double diff = Math.Abs(theta1 - theta2);
        double angle = Math.Min(diff, Math.Abs(180 - diff));
        return angle < minAngle;
    }
    public static bool LineSegmentsIntersect(CartezianLine line1, CartezianLine line2)
    {
        return (
            ((line2.pointB.y - line1.pointA.y) * (line2.pointA.x - line1.pointA.x) > (line2.pointA.y - line1.pointA.y) * (line2.pointB.x - line1.pointA.x)) !=
            ((line2.pointB.y - line1.pointB.y) * (line2.pointA.x - line1.pointB.x) > (line2.pointA.y - line1.pointB.y) * (line2.pointB.x - line1.pointB.x)) &&
            ((line2.pointA.y - line1.pointA.y) * (line1.pointB.x - line1.pointA.x) > (line1.pointB.y - line1.pointA.y) * (line2.pointA.x - line1.pointA.x)) !=
            ((line2.pointB.y - line1.pointA.y) * (line1.pointB.x - line1.pointA.x) > (line1.pointB.y - line1.pointA.y) * (line2.pointB.x - line1.pointA.x)));
    }
}
public struct CartezianPosition
{
    public readonly int x;
    public readonly int y;
    public CartezianPosition(int x,int y)
    {
        this.x = x;
        this.y = y;
    }
    public static int CalculateDistance(CartezianPosition point1, CartezianPosition point2)
    {
        return (point1.x - point2.x) * (point1.x - point2.x) + (point1.y - point2.y) * (point1.y - point2.y);
    }
    public static bool IsDistanceLessThan(CartezianPosition point1, CartezianPosition point2,int minDistance)
    {
        return CalculateDistance(point1, point2) < minDistance * minDistance;
    }

}