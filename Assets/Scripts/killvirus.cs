using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killvirus : MonoBehaviour
{
    // Start is called before the first frame update
   

   void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "virus")
        {
            Destroy(coll.gameObject);
        }
    }

}
