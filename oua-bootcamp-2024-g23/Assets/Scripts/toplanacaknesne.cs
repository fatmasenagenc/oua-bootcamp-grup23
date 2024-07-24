using UnityEngine;
using TMPro;

public class CharacterCollision : MonoBehaviour
{
    public int scorePerCollision = 10;
    public TMP_Text scoreTextMeshPro;
    public int score = 0;
    private void OnTriggerEnter(Collider collision)
    {
        // Karakter çöple çarpýþtýðýnda bu metot çaðrýlýr.
        // Collision, çöp objesini temsil eden collider bileþenidir.

        if (collision.CompareTag("Trash")) // Çarpýþan obje "Trash" etiketine sahipse
        {
            Destroy(collision.gameObject); // Çöpü yok et
            IncreaseScore(); // Skoru artýr
        }
    }

    void IncreaseScore()
    {
        score += scorePerCollision;
        scoreTextMeshPro.text = "Score: " + score.ToString();
        // Skoru artýran kod buraya gelecek
        // Örneðin bir UIManager üzerinden skoru güncelleyebiliriz

        // UIManager.Instance.IncreaseScore(1); // UIManager scriptinde IncreaseScore fonksiyonu çaðrýlýr
        // UIManager.Instance.UpdateScoreText(); // Skor textini günceller
    }
}

