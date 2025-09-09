using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float velocidad = 2f;
    public float direccion =1f;
    private Rigidbody2D rb2d;
    public bool checkGround;
    float movimiento;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movimiento = velocidad * Mathf.Sign(transform.localScale.x);
        transform.Translate(movimiento * Time.deltaTime, 0, 0);
        if (direccion > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        else if (direccion < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        checkGround = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        checkGround = false;
        direccion *= -1;
    }
}
