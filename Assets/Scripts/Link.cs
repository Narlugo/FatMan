using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link
{

    public Node node1;
    public Node node2;

    public float Distance
    {
        get
        {
            return (node1.transform.position - node2.transform.position).magnitude;
        }
    }

    public Link(Node n1, Node n2)
    {
        node1 = n1;
        node2 = n2;
    }

    public Vector3 MoveAlong(Node from, ref float distance, float speed)
    {
        Vector3 startPos = from.transform.position;
        Node to = (from == node1) ? node2 : node1;
        Vector3 endPos = to.transform.position;
        Vector3 dir = (endPos - startPos).normalized;
        Vector3 offset = dir * distance;
        offset += dir * speed * Time.deltaTime;
        distance = offset.magnitude;
        return startPos + offset;
    }

    public Node GetOpositeNode(Node n)
    {
        return (n == node1) ? node2 : node1;
    }

}
