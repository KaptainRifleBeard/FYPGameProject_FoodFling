using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Photon.Pun;

public class sl_P2PlayerControl : MonoBehaviour
{
    //NavMesh AI movement for click to move
    private NavMeshAgent myAgent;
    PhotonView view;

    //NEW MOVEMENT VARIABLE
    public GameObject targetDestionation;
    public GameObject inventoryVisible;

    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }


    void Start()
    {
        sl_p2InventoryManager.ClearAllInList();
        view = GetComponent<PhotonView>();
    }

    public void Update()
    {
        if (view.IsMine)  //Photon - check is my character's view
        {
            inventoryVisible.SetActive(true);

        }
        else
        {
            inventoryVisible.SetActive(false);
        }


        //NEW MOVEMENT - current using
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(1) && sl_P2ShootBehavior.p2Shoot == false)
        {

            if (Physics.Raycast(ray, out hit))
            {
                targetDestionation.transform.position = hit.point;
                myAgent.SetDestination(hit.point);
            }

        }

        myAgent.isStopped = true;
        myAgent.ResetPath();

        //Rotate player
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(ray, out rayLength))
        {
            Vector3 pointToLook = ray.GetPoint(rayLength);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }


    }



}
