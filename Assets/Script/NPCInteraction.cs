using UnityEngine;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour
{
    public GameObject dialoguePanel; // Panel UI nesnesini referans al�n
    public Text dialogueText; // Text UI nesnesini referans al�n
    public string npcDialogue = "Merhaba, ben NPC! Size nas�l yard�mc� olabilirim?";
    private bool isDialogueOpen = false;
    private bool isPlayerNearby = false;

    void Start()
    {
        dialoguePanel.SetActive(false); // Ba�lang��ta paneli kapal� tut
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
        dialoguePanel.SetActive(true); // Paneli etkinle�tir
        dialogueText.text = npcDialogue; // NPC diyalo�unu ayarla
        isDialogueOpen = true;
    }

    void CloseDialogue()
    {
        dialoguePanel.SetActive(false); // Paneli devre d��� b�rak
        isDialogueOpen = false;
    }

    public void AppendText(string newText)
    {
        dialogueText.text += "\n" + newText; // Yeni metni mevcut metne ekle
    }
}
