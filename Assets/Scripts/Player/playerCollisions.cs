using UnityEngine;

public class playerCollisions : MonoBehaviour
{
    public GameObject win;
    public GameObject lose;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DieTag"))
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            lose.SetActive(true);
            AudioManager.instance.GameOver();
        }
        else if (other.CompareTag("WinTag"))
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            win.SetActive(true);
        }
    }
}
