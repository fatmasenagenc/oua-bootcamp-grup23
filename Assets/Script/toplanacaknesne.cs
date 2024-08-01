
using UnityEngine;
using UnityEngine.UI;



public class CharacterCollision : MonoBehaviour
{
    public int scorePerCollision = 10;
    public Text countText;
    private int objectCount;
    public Text winMessageText;

    public int score = 0;
    void Start()
    {
        if (winMessageText != null)
        {
            winMessageText.enabled = false;
        }
        objectCount = 0; // Baþlangýçta toplanan obje sayýsýný sýfýrla
        UpdateCountText(); // Baþlangýçta metin kutusunu güncelle
    }
    void OnCollisionEnter(Collision collision)
    {
        // Karakter çöple çarpýþtýðýnda bu metot çaðrýlýr.
        // Collision, çöp objesini temsil eden collider bileþenidir.

        if (collision.gameObject.CompareTag("Trash"))
        {
            Destroy(collision.gameObject); // Çöpü yok et
            IncreaseScore(); // Skoru artýr
            objectCount++; // Toplanan obje sayýsýný bir artýr
            UpdateCountText(); // Metin kutusunu güncelle
        }
        if (objectCount>120)
        {
            winMessageText.enabled = true;
        }
    }
    void UpdateCountText()
    {
        countText.text = "Toplanan Objeler: " + objectCount.ToString(); // Metin kutusunu güncelle
    }

    void IncreaseScore()
    {
        score += scorePerCollision;

        // Skoru artýran kod buraya gelecek
        // Örneðin bir UIManager üzerinden skoru güncelleyebiliriz

        // UIManager.Instance.IncreaseScore(1); // UIManager scriptinde IncreaseScore fonksiyonu çaðrýlýr
        // UIManager.Instance.UpdateScoreText(); // Skor textini günceller
    }
}
