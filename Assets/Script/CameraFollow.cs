using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject player;
    public float FollowFaster = 10;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 temp = player.transform.position;
        temp.z = temp.z - 10;
        // Assign value to Camera position
        this.transform.position = new Vector3(Mathf.Lerp(this.transform.position.x, player.transform.position.x, Time.fixedDeltaTime * FollowFaster),
                                               Mathf.Lerp(this.transform.position.y, player.transform.position.y, Time.fixedDeltaTime * FollowFaster), temp.z);

    }
}
