using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket hýzý
    public float rotationSpeed = 100f; // Dönüþ hýzý

    void Update()
    {
        // Hareket iþlemleri
        if (Input.GetKey(KeyCode.W))
        {
            MoveUp();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveDown();
        }

        // Dönüþ iþlemi
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }

        // Space tuþuna basýldýðýnda ileri hareket iþlemi
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
        // Karakterin ileri doðru hareket etmesi için Vector3.forward kullanýlýr.
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);
    }
}
