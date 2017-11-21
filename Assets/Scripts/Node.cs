using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour
{
    private Vector3 position;

    public Node northNode;
    public Node ouestNode;
    public Node estNode;
    public Node southNode;

    private Link northLink;
    private Link westLink;
    private Link eastLink;
    private Link southLink;

    // Use this for initialization
    private void Awake()
    {
        position = transform.position;
        UpdateLinks();
    }

    private void UpdateLinks()
    {
        if (northNode != null)
        {
            if (northNode.southLink != null)
            {
                northLink = northNode.southLink;
            }
            else
            {
                northLink = new Link(this, northNode);
                northNode.southLink = northLink;
            }
        }
        if (ouestNode != null)
        {
            if (ouestNode.eastLink != null)
            {
                westLink = ouestNode.eastLink;
            }
            else
            {
                westLink = new Link(this, ouestNode);
                ouestNode.eastLink = westLink;
            }
        }
        if (estNode != null) 
        {
            if(estNode.westLink != null)
            {
                eastLink = estNode.westLink;
            }
            else
            {
                eastLink = new Link(this, estNode);
                estNode.westLink = eastLink;
            }
        }
        if (southNode != null)
        {
            if (southNode.northLink != null)
            {
                southLink = southNode.northLink;
            }
            else
            {
                southLink = new Link(this, southNode);
                southNode.northLink = southLink;
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public Vector3 getPos()
    {
        return position;
    }

    public Link GetLink(Orientation ori)
    {
        switch (ori)
        {
            case Orientation.NORTH:
                return northLink;
            case Orientation.SOUTH:
                return southLink;
            case Orientation.EAST:
                return eastLink;
            case Orientation.WEST:
                return westLink;
            default:
                return null;
        }
    }

}
