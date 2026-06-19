using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class collision : MonoBehaviour
{
    public int score=0;
    public TMP_Text t;
    public void Update()
    {
        if (score == 10)
        {
            Reset();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        score++;
        Destroy(collision.gameObject);
        t.text = score.ToString();
    }
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
