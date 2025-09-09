using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3 : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Vector3 initPos;
    public Vector2 margin;
    public AnimationCurve animCurve;
    [Range(0,1)]
    public float tSalto;
    public float velSalto;
    public int direction = 1;

    void Start()
    {
        initPos = transform.position;
    }

    void Update()
    {
        // Sumar a la t que mueve la posicion en Y
        tSalto += Time.deltaTime * velSalto;
        // Si se pasa de 1, lo vuelve 0
        if (tSalto > 1)
        {
            tSalto = 0;
        }

        // La posicion va a ser la Inicial + (0, la curva en el momento t multiplicado por la fuer Salto ,0)
        transform.position = initPos +
                            Vector3.up * jumpForce*animCurve.Evaluate(tSalto);
        if (direction > 0)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            if (transform.position.x > margin.y)
            {
                direction = -1;
            }
        }
        else
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            if (transform.position.x < margin.x)
            {
                direction = 1;
            }
        }
        initPos.x = transform.position.x;


    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(new Vector3(margin.x, transform.position.y, 0), 0.5f);
        Gizmos.DrawSphere(new Vector3(margin.y, transform.position.y, 0), 0.5f);
    }
}
