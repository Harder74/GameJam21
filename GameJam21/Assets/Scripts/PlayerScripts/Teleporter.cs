using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    public GameObject sight;
    [SerializeField]
    private GameObject player;
    private GameObject tempsight;
    private bool place;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            place = !place;
            if (place)
            {  
                tempsight = GameObject.Instantiate(sight, player.transform.position, Quaternion.identity);
            }
            else
            {
                player.transform.position = tempsight.transform.position;
                GameObject.DestroyImmediate(tempsight);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q)) 
        {
            place = !place;
            GameObject.DestroyImmediate(tempsight); 
        }
    }
}