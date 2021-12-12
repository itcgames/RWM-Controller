using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CombatTest
    {
        private Game m_game;
        private GameObject m_player;



        [SetUp]
        public void Setup()
        {
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
        }

        [UnityTest]
        public IEnumerator CombatEncounter()
        {
            m_player = GameObject.Find("Player");
            bool check = m_player.GetComponent<Movement>().ForceCombatEncounter();
            yield return new WaitForSeconds(1.0f);
            Assert.True(check);
        }
    }
}
