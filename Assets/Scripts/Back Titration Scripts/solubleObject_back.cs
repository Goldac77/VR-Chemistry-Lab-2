using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solubleObject_back : MonoBehaviour
{
    [SerializeField] GameObject weighingBoat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject == weighingBoat)
        {
            gameObject.transform.parent = weighingBoat.transform;
        }
    }
}
