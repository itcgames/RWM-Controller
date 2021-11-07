using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float m_speed = 2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            MoveUp();
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            MoveDown();
        }

    }

    public void MoveLeft()
    {
        transform.Translate(Vector2.left * Time.deltaTime * m_speed);
    }

    public void MoveRight()
    {
        transform.Translate(Vector2.right * Time.deltaTime * m_speed);
    }

    public void MoveUp()
    {
        transform.Translate(Vector2.up * Time.deltaTime * m_speed);
    }

    public void MoveDown()
    {
        transform.Translate(Vector2.down * Time.deltaTime * m_speed);
    }
}
