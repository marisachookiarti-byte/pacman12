using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class GameController : MonoBehaviour
    {
        public int score = 0;
        public int maxCoin = 10;
        public int scene = 1;
        
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
            if (score >= maxCoin)
            {
                SceneManager.LoadScene(scene);
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