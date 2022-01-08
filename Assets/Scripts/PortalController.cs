using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    [SerializeField] private Sprite mainSprite;
    [SerializeField] private Sprite touchSprite;
    [Space]
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private string nextSceneName = "Level01";

    private SpriteRenderer thisSpriteRenderer;

    void Start()
    {
        thisSpriteRenderer = GetComponent<SpriteRenderer>();
        thisSpriteRenderer.sprite = mainSprite;
    }

    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == playerTag)
        {
            thisSpriteRenderer.sprite = touchSprite;
            NextLevel();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == playerTag)
        {
            thisSpriteRenderer.sprite = mainSprite;
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
    }
}
