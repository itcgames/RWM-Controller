using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public int m_health;
    public bool m_isGameOver;

    [SerializeField]
    private GameObject m_playerModel;
    [SerializeField]
    private GameObject m_camera;

    private static Game m_gameInstance;

    // Start is called before the first frame update
    private void Start()
    {
        m_gameInstance = this;
    }

    // Creates a new game for testing purposes
    public void NewGame()
    {
        m_isGameOver = false;
        m_playerModel.transform.position = new Vector3(0, -3.22f, 0);
        m_playerModel.transform.eulerAngles = new Vector3(90, 180, 0);
        m_health = 0;
    }

    public Movement getPlayerModel()
    {
        return m_playerModel.GetComponent<Movement>();
    }

    public CameraFollow GetCameraFollow()
    {
        return m_camera.GetComponent<CameraFollow>();
    }
}
