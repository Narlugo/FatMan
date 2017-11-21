using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1f;
    public Node curNode;
    public Orientation curDir;
    public float minDistanceToTurn = .5f;
    private Link curLink;
    private Node nextNode;
    private float distance = 0;

    private bool stop = false;

    private bool haveTurn = false;

    // Use this for initialization
    void Start()
    {
        transform.position = curNode.getPos();
        curLink = curNode.GetLink(curDir);
        nextNode = curLink.GetOpositeNode(curNode);
    }

    // Update is called once per frame
    void Update()
    {

        if (distance > curLink.Distance)
        {
            curNode = nextNode;
            curLink = curNode.GetLink(curDir);
            nextNode = curLink.GetOpositeNode(curNode);
            distance = 0;
        }
        else if (Input.GetButtonDown("Left"))
        {
            if (curLink.Distance - distance < minDistanceToTurn)
            {
                curNode = nextNode;
                curDir = curDir.GetToLeft();
                curLink = curNode.GetLink(curDir);
                nextNode = curLink.GetOpositeNode(curNode);
                distance = 0;
            }
        }
        else if (Input.GetButtonDown("Right"))
        {
            if (curLink.Distance - distance < minDistanceToTurn)
            {
                curNode = nextNode;
                curDir = curDir.GetToRight();
                curLink = curNode.GetLink(curDir);
                nextNode = curLink.GetOpositeNode(curNode);
                distance = 0;
            }
        }

        if (!stop)
        {
            transform.position = curLink.MoveAlong(curNode, ref distance, speed);
        }
    }

}
