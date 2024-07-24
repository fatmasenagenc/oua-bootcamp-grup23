using UnityEngine;
using TMPro;

public class CharacterCollision : MonoBehaviour
{
    public int scorePerCollision = 10;
    public TMP_Text scoreTextMeshPro;
    public int score = 0;
    private void OnTriggerEnter(Collider collision)
    {
        // Karakter ��ple �arp��t���nda bu metot �a�r�l�r.
        // Collision, ��p objesini temsil eden collider bile�enidir.

        if (collision.CompareTag("Trash")) // �arp��an obje "Trash" etiketine sahipse
        {
            Destroy(collision.gameObject); // ��p� yok et
            IncreaseScore(); // Skoru art�r
        }
    }

    void IncreaseScore()
    {
        score += scorePerCollision;
        scoreTextMeshPro.text = "Score: " + score.ToString();
        // Skoru art�ran kod buraya gelecek
        // �rne�in bir UIManager �zerinden skoru g�ncelleyebiliriz

        // UIManager.Instance.IncreaseScore(1); // UIManager scriptinde IncreaseScore fonksiyonu �a�r�l�r
        // UIManager.Instance.UpdateScoreText(); // Skor textini g�nceller
    }
}

