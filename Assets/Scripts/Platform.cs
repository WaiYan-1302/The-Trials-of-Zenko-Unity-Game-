using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject orb;
    // Start is called before the first frame update
    void Start()
    {
        int randDiamond = Random.Range(0, 8);

        Vector3 orbPos = transform.position;
        orbPos.y += 1f;
         
        if (randDiamond < 1)
        {
            //0 spawn the diamond
            GameObject orbInstance = Instantiate(orb, orbPos, orb.transform.rotation) ;
            orbInstance.transform.SetParent(gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Fall", 0.3f);
        }

    }

    void Fall()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, 1f);
    }
}
