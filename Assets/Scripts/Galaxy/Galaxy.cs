using System;
using System.Collections;
using System.Collections.Generic;
public class Galaxy
{
    public static Galaxy galaxy;
    public int numberOfNodes = 100;
    public int numberOfArms = 0;

    public int maximumRadius = 100;
    public int minDistanceBetweenNodes = 10;
    Random random;
    public List<Node> nodes = new List<Node>();
    public Galaxy()
    {
        random = new Random();
        galaxy = this;
        Generate();
    }
    public int RandomNumber(int min, int max)
    {
        
        return random.Next(min, max);
    }
    public void Generate()
    {
        if (nodes.Count == 0)
        {
            CartezianPosition nodePosition = new CartezianPosition(RandomNumber(-maximumRadius, maximumRadius), RandomNumber(-maximumRadius, maximumRadius));
            nodes.Add(new Node(0, "Star" + 0, nodePosition));
            
        }
        if (numberOfArms == 0)
        {
            for (int i = 1; i < numberOfNodes; i++)
            {

                CartezianPosition nodePosition = new CartezianPosition( RandomNumber(-maximumRadius, maximumRadius), RandomNumber(-maximumRadius, maximumRadius) );
                
                    for (int j = 0; j < nodes.Count; j++)
                    {
                        if (CartezianPosition.IsDistanceLessThan(nodes[j].position, nodePosition, minDistanceBetweenNodes))
                        {
                            i--;
                            break;
                        }
                        else
                        {
                            nodes.Add(new Node(i, "Star" + i, nodePosition));
                            break;
                        }
                    }
                
                
            }

        }
    }

}
