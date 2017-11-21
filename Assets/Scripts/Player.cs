using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1f;
    public Node curNode;
    public Orientation startDir;
    public float minDistanceToTurn = .5f;
    private Link curLink;
    private Node nextNode;
    private float distance = 0;

    private bool stop = false;

    // Use this for initialization
    void Start()
    {
        transform.position = curNode.getPos();
        curLink = curNode.GetLink(startDir);
        nextNode = curLink.GetOpositeNode(curNode);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Left"))
        {
            if (curLink.Distance - distance < minDistanceToTurn)
            {
                curNode = nextNode;
                curLink = curNode.GetLink(Orientation.WEST);
                nextNode = curLink.GetOpositeNode(curNode);
                distance = 0;
            }
        }
        if (Input.GetButtonDown("Right"))
        {
            if (curLink.Distance - distance < minDistanceToTurn)
            {
                curNode = nextNode;
                curLink = curNode.GetLink(Orientation.EAST);
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
