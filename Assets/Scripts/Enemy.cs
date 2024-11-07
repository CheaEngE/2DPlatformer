using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 3;
    public float speed = 3;
    public Collider2D frontCollider;
    public Collider2D frontBottomCollider;
    public CompositeCollider2D terrainCollier;

    Vector2 vx;

    // Start is called before the first frame update
    void Start()
    {
        vx = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!frontBottomCollider.IsTouching(terrainCollier) || frontCollider.IsTouching(terrainCollier))
        {
            vx = -vx;
            transform.localScale = new Vector2(-transform.localScale.x, 1);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(vx * Time.fixedDeltaTime);
    }

    public void Hit(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<Rigidbody2D>().angularVelocity = 720;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0,10),ForceMode2D.Impulse);

            Invoke("DestroyThis", 2.0f);
        }
    }

    void DestroyThis()
    {
        Destroy(gameObject);
    }
}
