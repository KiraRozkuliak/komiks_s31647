using UnityEngine;

// Клас, який керує рухом гравця по вертикалі
public class VerticalPlayerController : MonoBehaviour
{
    [Header("Movement speed on Y axis")]
    public float moveSpeed = 5f; 
    // Швидкість руху по вертикалі

    [Header("Y axis movement limits (optional)")]
    public bool useBounds = false; 
    // Чи використовувати обмеження руху по осі Y

    public float minY = -5f; 
    // Нижня межа позиції по Y

    public float maxY = 5f;  
    // Верхня межа позиції по Y

    void Update()
    {
        float vertical = 0f;
        // Зберігає напрям руху (1, -1 або 0)

        // Перевірка натискання W або ↑ — рух вгору
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            vertical = 1f;
        }
        // Перевірка натискання S або ↓ — рух вниз
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            vertical = -1f;
        }

        // Вектор руху: (x=0, y=vertical, z=0)
        Vector3 move = new Vector3(0f, vertical, 0f) * moveSpeed * Time.deltaTime;

        // Додаємо рух до позиції об'єкта
        transform.position += move;

        // Якщо увімкнено обмеження — Clamp по Y
        if (useBounds)
        {
            Vector3 pos = transform.position;
            pos.y = Mathf.Clamp(pos.y, minY, maxY);
            transform.position = pos;
        }
    }
}

