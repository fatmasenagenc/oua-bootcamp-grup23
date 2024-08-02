
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



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
        objectCount = 0; // Ba�lang��ta toplanan obje say�s�n� s�f�rla
        UpdateCountText(); // Ba�lang��ta metin kutusunu g�ncelle
    }
    void OnCollisionEnter(Collision collision)
    {
        // Karakter ��ple �arp��t���nda bu metot �a�r�l�r.
        // Collision, ��p objesini temsil eden collider bile�enidir.

        if (collision.gameObject.CompareTag("Trash"))
        {
            Destroy(collision.gameObject); // ��p� yok et
            IncreaseScore(); // Skoru art�r
            objectCount++; // Toplanan obje say�s�n� bir art�r
            UpdateCountText(); // Metin kutusunu g�ncelle
        }
        if (objectCount == 10)
        {
            //winMessageText.enabled = true;
            SceneManager.LoadScene(3);

        }
    }
    void UpdateCountText()
    {
        countText.text = "Toplanan ��pler: " + objectCount.ToString(); // Metin kutusunu g�ncelle
    }

    void IncreaseScore()
    {
        score += scorePerCollision;

        // Skoru art�ran kod buraya gelecek
        // �rne�in bir UIManager �zerinden skoru g�ncelleyebiliriz

        // UIManager.Instance.IncreaseScore(1); // UIManager scriptinde IncreaseScore fonksiyonu �a�r�l�r
        // UIManager.Instance.UpdateScoreText(); // Skor textini g�nceller
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
