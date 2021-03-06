using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class CatDogPatrol : MonoBehaviour
{
    PhotonView view;
    int index;

    private Waypoints waypoints1;

    private int destPoint = 0;
    private NavMeshAgent agent;

    GameObject obj;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Spawn1")
        {
            index = 1;
            Debug.Log(index);
        }
        else if(other.gameObject.tag == "Spawn2")
        {
            index = 2;
            Debug.Log(index);
        }
        else if (other.gameObject.tag == "Spawn3")
        {
            index = 3;
            Debug.Log(index);
        }
        else if (other.gameObject.tag == "Spawn4")
        {
            index = 4;
            Debug.Log(index);
        }

        if (other.gameObject.tag == "Despawn")
        {
            view.RPC("DestroyCatDog", RpcTarget.All);
            //PhotonNetwork.Destroy(gameObject);
            CatDogSpawn.canSpawn = true;
        }

        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Player2")
        {
            agent.speed = 35;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        waypoints1 = FindObjectOfType<Waypoints>();

        if (index == 1)
        {
            //view.RPC("GoToNextPoint1", RpcTarget.All);
            GoToNextPoint1();
        }
        else if (index == 2)
        {
            //view.RPC("GoToNextPoint2", RpcTarget.All);
            GoToNextPoint2();
        }
        else if (index == 3)
        {
            //view.RPC("GoToNextPoint3", RpcTarget.All);
            GoToNextPoint3();
        }
        else if (index == 4)
        {
            //view.RPC("GoToNextPoint4", RpcTarget.All);
            GoToNextPoint4();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            if(index == 1)
            {
                //view.RPC("GoToNextPoint1", RpcTarget.All);
                GoToNextPoint1();
            }
            else if(index == 2)
            {
                //view.RPC("GoToNextPoint2", RpcTarget.All);
                GoToNextPoint2();
            }
            else if(index == 3)
            {
                //view.RPC("GoToNextPoint3", RpcTarget.All);
                GoToNextPoint3();
            }
            else if(index == 4)
            {
                //view.RPC("GoToNextPoint4", RpcTarget.All);
                GoToNextPoint4();
            }
            
        }
            
    }

    [PunRPC]
    public void GoToNextPoint1()
    {
        if (waypoints1.Waypoint1.Count == 0)
        {
            return;
        }

        agent.SetDestination (waypoints1.Waypoint1[destPoint].position);

        destPoint = (destPoint + 1) % waypoints1.Waypoint1.Count;
    }

    [PunRPC]
    public void GoToNextPoint2()
    {
        if (waypoints1.Waypoint2.Count == 0)
        {
            return;
        }

        agent.SetDestination(waypoints1.Waypoint2[destPoint].position);

        destPoint = (destPoint + 1) % waypoints1.Waypoint2.Count;
    }

    [PunRPC]
    public void GoToNextPoint3()
    {
        if (waypoints1.Waypoint3.Count == 0)
        {
            return;
        }

        agent.SetDestination(waypoints1.Waypoint3[destPoint].position);

        destPoint = (destPoint + 1) % waypoints1.Waypoint3.Count;
    }

    [PunRPC]
    public void GoToNextPoint4()
    {
        if (waypoints1.Waypoint4.Count == 0)
        {
            return;
        }

        agent.SetDestination(waypoints1.Waypoint4[destPoint].position);

        destPoint = (destPoint + 1) % waypoints1.Waypoint4.Count;
    }

    [PunRPC]
    public void DestroyCatDog()
    {
        Destroy(gameObject);
    }

}
