using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solubleObject_back : MonoBehaviour
{
    [SerializeField] GameObject weighingBoat;
    Vector3 startWorldScale;
    Transform startParent;
    // Start is called before the first frame update
    void Start()
    {
        startParent = gameObject.transform.parent;
        startWorldScale = gameObject.transform.lossyScale;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == weighingBoat)
        {
            Vector3 weighingBoatScale = weighingBoat.transform.lossyScale;
            gameObject.transform.parent = weighingBoat.transform;
            gameObject.transform.localScale = new Vector3(startWorldScale.x/weighingBoatScale.x, startWorldScale.y / weighingBoatScale.y, startWorldScale.z / weighingBoatScale.z);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject == weighingBoat)
        {
            gameObject.transform.parent = startParent;
            gameObject.transform.localScale = new Vector3(startWorldScale.x / startParent.lossyScale.x, startWorldScale.y / startParent.lossyScale.y, startWorldScale.z / startParent.lossyScale.z);
        }
    }
}
