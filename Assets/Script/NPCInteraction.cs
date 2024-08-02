using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    public GameObject dialoguePanel; // Panel UI nesnesini referans alýn
    public Text dialogueText; // Text UI nesnesini referans alýn
    public string npcDialogue = "Merhaba, ben NPC! Size nasýl yardýmcý olabilirim?";
    private bool isDialogueOpen = false;
    private bool isPlayerNearby = false;

    void Start()
    {
        dialoguePanel.SetActive(false); // Baþlangýçta paneli kapalý tut
    }

    void Update()
    {
        //&& Input.GetKeyDown(KeyCode.E)
        if (isPlayerNearby)
        {
            OpenDialogue();
            /*if (isDialogueOpen)
            {
                CloseDialogue();
            }
            else
            {
                OpenDialogue();
            }*/
        } else
        {
            CloseDialogue();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            CloseDialogue();
        }
    }

    void OpenDialogue()
    {
        dialoguePanel.SetActive(true); // Paneli etkinleþtir
        dialogueText.text = npcDialogue; // NPC diyaloðunu ayarla
        isDialogueOpen = true;
    }

    void CloseDialogue()
    {
        dialoguePanel.SetActive(false); // Paneli devre dýþý býrak
        isDialogueOpen = false;
    }

    public void AppendText(string newText)
    {
        dialogueText.text += "\n" + newText; // Yeni metni mevcut metne ekle
    }
}
