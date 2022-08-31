using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    private Vector2 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        if(GameManager.instance.isGameEnd) return;
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.MovePosition(rb.position + new Vector2(moveDirection.x * moveSpeed * Time.deltaTime, moveDirection.y * moveSpeed * Time.deltaTime));
        //rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    public void SetSlow()
    {
        moveSpeed = 3;
        StartCoroutine(ResetSpeed());
    }

    public void SetFast()
    {
        moveSpeed = 8;
        StartCoroutine(ResetSpeed());
    }

    IEnumerator ResetSpeed()
    {
        yield return new WaitForSeconds(3);
        moveSpeed = 5;
    }
}
