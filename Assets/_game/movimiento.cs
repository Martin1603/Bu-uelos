using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float velocidad;
    public float direccion;
    public float fuerzaSalto;
    private Rigidbody2D rb2d;
    public bool enPiso;
    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        transform.Translate(velocidad * Time.deltaTime * (direccion + Input.GetAxis("Horizontal")), 0, 0);
        if (direccion > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (direccion < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
    public void CambiaDireccion(float _direccion)
    {
        direccion = _direccion;
    }
    public void Saltar()
    {
        if(enPiso)
        {
            rb2d.AddForce(new Vector2(0, fuerzaSalto));
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        enPiso = true;
        if (other.gameObject.CompareTag("Box"))
        {
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision2D)
    {
        enPiso =false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
