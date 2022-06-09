using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
        Debug.Log("Created By Hitnes Muharram - 149251970101-41");
        SceneManager.LoadScene("GamePong");
    }
    public void OpenAuthor()
    {
        Debug.Log("Created By Hitnes");
    }
}
