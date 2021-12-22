using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject player;
    public int speed;
    public LayerMask enemyLayer;
    void Start()
    {
        player = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");//(-1, 1)
        float vertical = Input.GetAxis("Vertical");//(-1, 1)
        if (horizontal != 0)
        {
            if (horizontal < 0)
            {
                player.GetComponent<SpriteRenderer>().flipX=true;
            }
            else
            {
                player.GetComponent<SpriteRenderer>().flipX = false;
            }
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(horizontal * speed, player.GetComponent<Rigidbody2D>().velocity.y);
            player.GetComponent<Animator>().SetBool("Walking", true);
        }
        else
        {
            player.GetComponent<Animator>().SetBool("Walking", false);
        }
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Collider2D[] enemy = Physics2D.OverlapCircleAll(this.transform.position, 2, enemyLayer);

            for (int i = 0; i < enemy.Length; i++)
            {
                if (enemy[i].GetComponent<Enemy>() != null)
                {
                    enemy[i].GetComponent<Enemy>().health-=50;
                }
            }
        }
    }

    public void AmWalking()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position, 2);

    }
}
