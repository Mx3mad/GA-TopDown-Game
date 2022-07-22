using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBodyController : MonoBehaviour
{
    [SerializeField] int health = 4;
    Animator animator = null;
    GameObject player = null;
    Rigidbody2D rb2d = null;


    [SerializeField] float moveSpeed = 4f;

    public Vector3 initialPos;
    float colorChangeTimer = 0.169f;

    private void Start()
    {
        initialPos = gameObject.transform.position;
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();
    }

    void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (gameObject.GetComponent<SpriteRenderer>().color == Color.white)
            StartCoroutine(ChangeEnemyColor());
    }

    IEnumerator ChangeEnemyColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(colorChangeTimer);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public bool MoveToPlayer()
    {
        if (player != null)
        {
            MoveToTarget(player.transform.position);
            return true;
        }
        return false;
    }

    public void MoveToTarget(Vector2 targetPos)
    {
        Vector2 positionAfterOneStep = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        rb2d.MovePosition(positionAfterOneStep);
        if (targetPos.x > transform.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Weapon>() != null)
        {
            TakeDamage(collision.GetComponent<Weapon>().damageAmount);
        }
    }
}
