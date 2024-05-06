using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    
    public void ActivatePlayer()
    {
        gameObject.SetActive(true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Obstacle")){
            gameObject.SetActive(false);
            UiManager.Instance.GameOver();
        }
    }
}
