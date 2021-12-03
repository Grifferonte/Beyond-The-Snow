using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    [SerializeField]Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position,gameObject.transform.position)<5 && player.getBranchs()>=3){
            player.playerRest();
        }
        // if(Vector3.Distance(player.transform.position,gameObject.transform.position)>5){
        //     //player.outOfSafeZone();
        // }
    }


}
