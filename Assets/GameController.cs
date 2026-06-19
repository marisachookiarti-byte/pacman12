using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class GameController : MonoBehaviour
    {
        public int score = 0;
        public int maxCoin = 10;
        
        public GameObject coin;
        public PacmanController pacman;
        public TMP_Text textMeshPro;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            pacman.eatCoinEvent.AddListener(OnPacmanEatCoin);
            
            for(int i=0; i < maxCoin; i++) {
                Instantiate(coin, new Vector3(Random.Range(-10, 10), Random.Range(-4, 4), 0), pacman.transform.rotation);
            }
        }

        public void Update()
        {
            if (score >= 10)
            {
                Reset();
            }
        }
        
        private void OnPacmanEatCoin(Collision2D collision)
        {
            score++;
            Destroy(collision.gameObject);
            textMeshPro.text = score.ToString();
        }
        
        
        public void Reset()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}