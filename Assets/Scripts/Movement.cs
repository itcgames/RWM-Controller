﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float m_speed = 2;
    [SerializeField]
    private float m_triggerChance = 1.1f;
    private bool m_isWalking; 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) 
            || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)
            || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)
            || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)
            )
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
