using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BackStab : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private float maxDistance;
    [SerializeField] private float seeDistance;

    [SerializeField] private GameObject canvas;

    [SerializeField] private Material green;
    [SerializeField] private Material red;
    [SerializeField] private Material blue;
    [SerializeField] private float angle = 0.95f;
    [SerializeField] private float seeAngle = 0.45f;


    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;

        float dotProduct = Vector3.Dot(transform.forward, direction.normalized);
        float dotProductDirection = Vector3.Dot(transform.forward.normalized, player.transform.forward.normalized);

        if (dotProduct < -0.8f && dotProductDirection > angle && direction.magnitude <= maxDistance && characterMovement.instance.GetCanBackStab())
        {
            print("Tah le backstab");
            GetComponent<MeshRenderer>().material = green;
        }
        else if (dotProduct > seeAngle && direction.magnitude <= seeDistance)
        {
            Debug.DrawRay(transform.position, direction);
            RaycastHit hit;
            if(Physics.Raycast(transform.position, direction, out hit))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    characterMovement.instance.SetCanBackStab(false);
                    print("Vu");
                    canvas.SetActive(true);
                }
            }
        }
        else
        {
            GetComponent<MeshRenderer>().material = red;
            canvas.SetActive(false);
            characterMovement.instance.SetCanBackStab(true);
        }
        

    }
}

