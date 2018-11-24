using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectRedBottleCaps : MonoBehaviour {

    void OnTriggerEnter(Collider collision)
    {
        if(collision.name == "Player"){
            Destroy(gameObject);
            collision.GetComponent<PlayerScript>().totalPoints = collision.GetComponent<PlayerScript>().totalPoints + 10;
            collision.GetComponent<PlayerScript>().redPoints = collision.GetComponent<PlayerScript>().redPoints + 1;
        }
        else if (collision.gameObject.tag.Equals("enemy")){
            Destroy(gameObject);
        }
    }
}
