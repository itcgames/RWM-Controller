using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class overworldSystemTest
    {
        private Game m_game;
        private GameObject m_instance;
        private GameObject m_player;
        private Animator m_animator;



        [SetUp]
        public void Setup()
        {
            SceneManager.LoadScene("Overworld", LoadSceneMode.Single);
            GameObject gameGameObject =
                MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
            m_game = gameGameObject.GetComponent<Game>();
        }
        [TearDown]
        public void Teardown()
        {
            if (m_game)
            {
                Object.Destroy(m_game);
            }

            if (m_instance)
            {
                Object.Destroy(m_instance);
            }

            if (m_animator)
            {
                Object.Destroy(m_animator);
            }

        }
        [UnityTest]
        public IEnumerator SpawnPlayer()
        {
            bool m_check = m_game.CheckPlayer();
            yield return new WaitForSeconds(1.0f);
            Assert.AreEqual(true, m_check);
        }

        [UnityTest]
        public IEnumerator EnterTown()
        {
            m_instance = GameObject.Find("town");
            m_player = GameObject.Find("Player");
            m_animator = GameObject.Find("Fade").GetComponent<Animator>();
            m_instance.transform.position = m_player.transform.position;
            Debug.Log("Has entered Town");
            m_instance = GameObject.Find("overworld");
            m_instance.transform.position = m_player.transform.position;
            yield return new WaitForSeconds(4.0f);
            int m_sceneNum = m_game.GetActiveIndex();
            Assert.AreEqual(1, m_sceneNum);
        }

        [UnityTest]
        public IEnumerator EnterOverworld()
        {
            SceneManager.LoadScene("Town", LoadSceneMode.Single);
            yield return new WaitForSeconds(0.1f);
            m_instance = GameObject.Find("overworld");
            m_player = GameObject.Find("Player");
            m_animator = GameObject.Find("Fade").GetComponent<Animator>();
            m_instance.transform.position = m_player.transform.position;
            yield return new WaitForSeconds(0.1f);
            Debug.Log("Has entered Overworld");
            m_instance = GameObject.Find("town");
            yield return new WaitForSeconds(0.1f);
            m_instance.transform.position = m_player.transform.position;
            yield return new WaitForSeconds(4.0f);
            int m_sceneNum = m_game.GetActiveIndex();
            Assert.AreEqual(0, m_sceneNum);
        }

        [UnityTest]
        public IEnumerator Transition()
        {
            m_instance = GameObject.Find("Town");
            m_player = GameObject.Find("Player");
            m_animator = GameObject.Find("Fade").GetComponent<Animator>();
            m_instance.transform.position = m_player.transform.position;
            m_animator.GetBool("Start");
            Debug.Log("Has entered Town");
            m_instance = GameObject.Find("Overworld");
            m_instance.transform.position = m_player.transform.position;
            yield return new WaitForSeconds(1.0f);
            Assert.True(m_animator.GetBool("Start"));
        }

    }
}
