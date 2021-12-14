using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float m_speed = 2;
    [SerializeField]
    private float m_triggerChance = 1.1f;
    private Vector2 m_input;

    // Update is called once per frame
    void Update()
    {
        m_input.x = Input.GetAxisRaw("Horizontal");
        m_input.y = Input.GetAxisRaw("Vertical");

        if (m_input.x < 0)
        {
            MoveLeft();
        }
        if(m_input.x > 0)
        {
            MoveRight();
        }

        if(m_input.y < 0)
        {
            MoveDown();
        }

        if(m_input.y > 0)
        {
            MoveUp();
        }

        if (m_input.SqrMagnitude() != 0)
        {
            CombatEncounter();
        }
    }

    /// <summary>
    /// Add your combat scene here
    /// </summary>
    void CombatEncounter()
    {

        if (Random.Range(1.0f, 100.0f) <= m_triggerChance)
        {
            Debug.Log("You have encountered an enemy!");
            // add scene for battle
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

    public bool ForceCombatEncounter()
    {
        return true;
    }

}
