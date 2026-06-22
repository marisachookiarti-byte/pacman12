using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class GameController : MonoBehaviour
    {
        private static GameController _instance;
        
        public int score = 0;
        public int maxCoin = 10;
        
        public GameObject coin;
        public PacmanController pacman;
        public TMP_Text textMeshPro;
        
        public LevelScriptableObject currentLevel;
        public List<LevelScriptableObject> levels;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            if (_instance != null)
            {
                Destroy(this);
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);
            
            pacman.eatCoinEvent.AddListener(OnPacmanEatCoin);

            AdvanceLevel(levels[0]);
        }

        void AdvanceLevel(LevelScriptableObject newLevel)
        {
            currentLevel = newLevel;
            maxCoin = currentLevel.maxCoin;

            for(int i=0; i < maxCoin; i++) {
                Instantiate(coin, new Vector3(Random.Range(-10, 10), Random.Range(-4, 4), 0), pacman.transform.rotation);
            }
        }

        public void Update()
        {
            if (score >= maxCoin)
            {
                score = 0;
                for (var index = 0; index < levels.Count; index++)
                {
                    var level = levels[index];
                    if (level == currentLevel)
                    {
                        AdvanceLevel(levels[index++]);
                    }
                }
            }
        }
        
        private void OnPacmanEatCoin(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("coin")){
                score++;
                Destroy(collision.gameObject);
                textMeshPro.text = score.ToString();
            }
        }
        
        
        public void Reset()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}