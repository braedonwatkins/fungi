using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killbox : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Destructable")
        {
            // Debug.Log("TODO: Destroy! ");
            Destroy(other.gameObject);
        }
    }
}
