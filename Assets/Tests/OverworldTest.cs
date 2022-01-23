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
            SceneManager.LoadScene(1);
            yield return new WaitForSeconds(0.1f);
            m_instance = GameObject.Find("town");
            m_player = GameObject.Find("Player");
            m_animator = GameObject.Find("Fade").GetComponent<Animator>();
            m_instance.transform.position = m_player.transform.position;
            Debug.Log("Has entered Town");
            SceneManager.LoadScene(2);
            yield return new WaitForSeconds(0.1f);
            m_instance = GameObject.Find("overworld");
            m_player = GameObject.Find("Player");
            m_instance.transform.position = m_player.transform.position;
            yield return new WaitForSeconds(1.0f);
            Assert.AreEqual(2, m_game.GetActiveIndex());
        }

        [UnityTest]
        public IEnumerator EnterOverworld()
        {
            SceneManager.LoadScene(2);
            yield return new WaitForSeconds(0.1f);
            m_instance = GameObject.Find("overworld");
            m_player = GameObject.Find("Player");
            m_animator = GameObject.Find("Fade").GetComponent<Animator>();
            m_instance.transform.position = m_player.transform.position;
            yield return new WaitForSeconds(0.1f);
            Debug.Log("Has entered Overworld");
            SceneManager.LoadScene(1);
            yield return new WaitForSeconds(0.1f);
            m_instance = GameObject.Find("town");
            m_player = GameObject.Find("Player");
            m_instance.transform.position = m_player.transform.position;
            yield return new WaitForSeconds(1.0f);
            Assert.AreEqual(1, m_game.GetActiveIndex());
        }

        [UnityTest]
        public IEnumerator Transition()
        {
            SceneManager.LoadScene(1);
            yield return new WaitForSeconds(1.0f);
            m_instance = GameObject.Find("town");
            m_player = GameObject.Find("Player");
            m_instance.transform.position = m_player.transform.position;
            Debug.Log("Has entered Town");
            SceneManager.LoadScene(2);
            yield return new WaitForSeconds(0.1f);
            m_instance = GameObject.Find("overworld");
            m_player = GameObject.Find("Player");
            m_animator = GameObject.Find("Fade").GetComponent<Animator>();
            m_animator.GetBool("Start");
            m_instance.transform.position = m_player.transform.position;
            yield return new WaitForSeconds(1.0f);
            Assert.True(m_animator.GetBool("Start"));
        }

    }
}
