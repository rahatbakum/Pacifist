using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    public Sprite mainSprite;
    public Sprite touchSprite;
    [Space]
    public string playerTag = "Player";
    public string nextSceneName = "Level01";
    public bool isAutomatic = true; //is Automatically set scene name

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

    string intToString (int number, int stringLength)
    {
        string stringNumber = number.ToString();
        string ans = "";
        for(int i = 0; i < stringLength; i++)
        {
            if (stringNumber.Length > i)
                ans = stringNumber[stringNumber.Length - i - 1] + ans;
            else
                ans = "0" + ans;
        }
        return ans;
    }

    string nextNameByName(string name)
    {
        int sceneNumber;
        if(!int.TryParse(name.Substring(name.Length-2, 2), out sceneNumber))
        {
            return nextSceneName;
        }
        return name.Substring(0,name.Length-2) + intToString(sceneNumber + 1, 2);
    }

    void NextLevel()
    {
        string nextSceneNameFinal = nextSceneName;
        if (isAutomatic)
            nextSceneNameFinal = nextNameByName(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(nextSceneNameFinal, LoadSceneMode.Single);
    }
}
