using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [SerializeField] private float scale;
    [SerializeField] private float forceScale;
    // Start is called before the first frame update
    private void Start()
    {

    }
    private void Jump()
    {
        Rigidbody2D m = this.GetComponent<Rigidbody2D>();
        m.AddForce(Vector2.up * forceScale);
    }
    bool canJump = true;
    // Update is called once per frame
    private void Update()
    {
        Vector2 vec = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            if (canJump)
            {
                print("jump!");
                Jump();
                canJump = false;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            vec += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vec += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vec += Vector2.right;
        }
        vec = vec.normalized * scale;
        this.GetComponent<Transform>().Translate(vec);
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        print("collide");
        if (collisionInfo.collider.tag == "platform")
        {
            canJump = true;
        }
    }
}