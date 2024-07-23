using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket h�z�
    public float rotationSpeed = 100f; // D�n�� h�z�

    void Update()
    {
        // Hareket i�lemleri
        if (Input.GetKey(KeyCode.W))
        {
            MoveUp();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveDown();
        }

        // D�n�� i�lemi
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }

        // Space tu�una bas�ld���nda ileri hareket i�lemi
        if (Input.GetKey(KeyCode.Space))
        {
            MoveForward();
        }
    }

    void MoveUp()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }

    void MoveDown()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }

    void RotateLeft()
    {
        transform.Rotate(Vector3.down, rotationSpeed * Time.deltaTime);
        
    }

    void RotateRight()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
       
    }

    void MoveForward()
    {
        // Karakterin ileri do�ru hareket etmesi i�in Vector3.forward kullan�l�r.
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
    }
}
