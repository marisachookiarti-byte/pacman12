using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Yarn.Unity;

namespace DefaultNamespace
{
    public class GameController : MonoBehaviour
    {
        private static GameController _instance;
        
        public int score = 0;
        public int maxCoin = 0;//-5
        
        public GameObject coin;
        public GameObject pac;
        public GameObject palace;
        public PacmanController pacman;
        public TMP_Text textMeshPro;

        public DialogueRunner dialogueRunner;
        public string[] node = { "A", "B", "C", "D", "E" };

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            pacman.eatCoinEvent.AddListener(OnPacmanEatCoin);
            pacman.hitEvent.AddListener(OnEnemyHit);
            AdvanceLevel();
        }

        void AdvanceLevel()
        {
            maxCoin += 5;
            pac.transform.Translate(0, 0, 0);
            for(int i=0; i < maxCoin; i++) {
                Instantiate(coin, new Vector3(Random.Range(-10, 10), Random.Range(-4, 4), 0), pacman.transform.rotation);
            }
            Instantiate(palace, new Vector3(Random.Range(-10, 10), Random.Range(-4, 4), 0), pacman.transform.rotation);

        }

        public void Update()
        {
            if (score >= maxCoin)
            {
                dialogueRunner.StartDialogue(node[Random.Range(0,node.Length)]);
                score = 0;
                AdvanceLevel();
            }
        }
        
        private void OnPacmanEatCoin(Collision2D collision)
        {
            score++;
            Destroy(collision.gameObject);
            textMeshPro.text = score.ToString();
        }
        private void OnEnemyHit(Collision2D collision)
        {
            Reset();
        }
        
        public void Reset()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}