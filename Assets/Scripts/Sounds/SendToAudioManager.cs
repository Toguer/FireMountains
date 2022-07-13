using UnityEngine.SceneManagement;
using UnityEngine;

public class SendToAudioManager : MonoBehaviour
{
    private string sceneName;
    public string mainMenuSceneName;
    public string storyBoardScene;
    public string noahRoomScene;
    public string puebloScene;
    private void Start()
    {
        

    }

    public void LoadSound(string soundName)
    {
        AudioManager.instance.Play(soundName);
    }
    public void StopAudio(string soundName)
    {
        AudioManager.instance.Stop(soundName);
    }
     void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        sceneName = scene.name;
        Debug.Log(sceneName);
        if (sceneName == mainMenuSceneName)
        {
            //AudioManager.instance.Stop("Worlds");
            AudioManager.instance.Stop("Pueblo");
            AudioManager.instance.Stop("NoahRoom");
            AudioManager.instance.Play("MainMenu");
            Debug.Log("Play Main Menu");
        }

        if (sceneName == storyBoardScene)
        {
            AudioManager.instance.Stop("MainMenu");
            AudioManager.instance.Play("StoryBoard");
        }

        if (sceneName == noahRoomScene)
        {
            AudioManager.instance.Stop("MainMenu");
            AudioManager.instance.Stop("StoryBoard");
            AudioManager.instance.Stop("Pueblo");
            AudioManager.instance.Play("NoahRoom");
        }
        if (sceneName == puebloScene)
        {
            AudioManager.instance.Stop("MainMenu");
            AudioManager.instance.Stop("StoryBoard");
            AudioManager.instance.Stop("NoahRoom");
            AudioManager.instance.Play("Pueblo");
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
