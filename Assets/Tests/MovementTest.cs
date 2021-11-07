using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
   

    public class MovementTest
    {
        private Game m_game;

        [SetUp]
        public void Setup()
        {
            GameObject gameGameObject =
                MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
            m_game = gameGameObject.GetComponent<Game>();
        }

        [UnityTest]
        public IEnumerator MoveLeft()
        {

            float m_initialXPos = m_game.getPlayerModel().transform.position.x;
            m_game.getPlayerModel().MoveLeft();
            yield return new WaitForSeconds(0.1f);

            Assert.Less(m_game.getPlayerModel().transform.position.x, m_initialXPos);
            
        }

        [UnityTest]
        public IEnumerator MoveRight()
        {
            float m_initialXPos = m_game.getPlayerModel().transform.position.x;
            m_game.getPlayerModel().MoveRight();
            yield return new WaitForSeconds(0.1f);

            Assert.Greater(m_game.getPlayerModel().transform.position.x, m_initialXPos);
        }
        [UnityTest]
        public IEnumerator MoveUp()
        {

            float m_initialYPos = m_game.getPlayerModel().transform.position.y;
            m_game.getPlayerModel().MoveUp();
            yield return new WaitForSeconds(0.1f);

            Assert.Greater(m_game.getPlayerModel().transform.position.x, m_initialYPos);

        }

        [UnityTest]
        public IEnumerator MoveDown()
        {
            float m_initialYPos = m_game.getPlayerModel().transform.position.y;
            m_game.getPlayerModel().MoveDown();
            yield return new WaitForSeconds(0.1f);

            Assert.Less(m_game.getPlayerModel().transform.position.y, m_initialYPos);
        }
    }
}
