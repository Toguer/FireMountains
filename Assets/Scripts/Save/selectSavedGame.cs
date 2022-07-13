using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class selectSavedGame : MonoBehaviour
{
    // Start is called before the first frame update
    private int selectedGame = 0;
    public List<GameObject> buttonsGame;

    [Tooltip("Arrastrar el boton de play")]
    public GameObject playButton;
    [Tooltip("Arrastrar el boton para empezar partida nueva")]
    public GameObject playNewGameButton;
    [Tooltip("Arrastrar el boton de borrar partida.")]
    public GameObject deleteButton;
    [SerializeField] private string SceneStoryBoard = "StoryBoard";
    [SerializeField] private string _ScenePueblo = "new_pueblo";
    public TextMeshProUGUI LvlName;
    public TextMeshProUGUI LvlDescription;
    [Tooltip("Aqui se selecciona el objeto que llevará la imagen")]
    public Image progressImage;
    [SerializeField] private List<Image> loadImages;
    public List<Color> colorList;
    public GameObject imageHide;

    void Start()
    {
        SaveManager.Init();

        bool gameSavedExists = false;

        for (int i = 1; i <= buttonsGame.Count; i++)
        {
            gameSavedExists = SaveManager.CheckGameSavedExists(i);
            buttonsGame[i - 1].GetComponentInChildren<TextMeshProUGUI>().text = gameSavedExists ? "Load\nGame" : "New\nGame";
        }

        SelectGame(1);
    }

    public void developerGame(int num)
    {
        testSaveObject saveObject = new testSaveObject
        {
            _skill1 = true,
            _skill2 = true,
            _skill3 = true,
            tutorial = true,
            panadera = true
        };
        string json = JsonUtility.ToJson(saveObject);
        SaveManager.Save(json, num);
        SceneManager.LoadScene(SceneStoryBoard);
    }

    public void newGame()
    {
        //Lo que hacemos es crear un nuevo fichero de guardado con valores por defecto. 
        testSaveObject saveObject = new testSaveObject
        {
            _skill1 = false,
            _skill2 = false,
            _skill3 = false,
            tutorial = true,
            panadera = false
        };
        AudioManager.instance.Play("NewGame");
        string json = JsonUtility.ToJson(saveObject);
        SaveManager.Save(json, selectedGame);
        SceneManager.LoadScene(SceneStoryBoard);
    }

    private int checkGames()
    {
        return SaveManager.checkExistLoads();
    }

    public void SelectGame(int num)
    {
        bool gameSavedExists = SaveManager.CheckGameSavedExists(num);
        AudioManager.instance.Play("SelectGame");
        selectedGame = num;
        LvlName.text = "Game #" + num;
        playNewGameButton.SetActive(gameSavedExists ? false : true);
        deleteButton.GetComponent<Button>().interactable = gameSavedExists ? true : false;
        deleteButton.GetComponent<Image>().CrossFadeAlpha(gameSavedExists ? 1f : 0.5f, 0.2f, true);
        deleteButton.GetComponentInChildren<TextMeshProUGUI>().CrossFadeAlpha(gameSavedExists ? 1f : 0.5f, 0.2f, true);
        playButton.SetActive(gameSavedExists ? true : false);
        LvlDescription.text = gameSavedExists ? "" : "New roadmap for the scouting diary." +
            " Your journey along with Noah starts here. Are you ready to find the Fire Mountains?";
        if (!gameSavedExists)
        {
            progressImage.color = colorList[num - 1];
            imageHide.SetActive(false);
        }
        else
        {
            imageHide.SetActive(true);
        }


    }

    public void Load()
    {
        string saveString = SaveManager.especificLoad(selectedGame);
        if (saveString != null)
        {
            testSaveObject saveObject = JsonUtility.FromJson<testSaveObject>(saveString);
            //valor = saveObject.ValorGuardado;
            saveInformation.SaveInformation.loadHere(saveObject._skill1, saveObject._skill2,
                saveObject._skill3, saveObject.panadera, saveObject._npc1, saveObject._npc2, saveObject._npc3);
            //asignar los valores
            SceneManager.LoadScene(_ScenePueblo);
        }
    }

    public void DeleteGame()
    {
        SaveManager.Delete(selectedGame);
        buttonsGame[selectedGame - 1].GetComponentInChildren<TextMeshProUGUI>().text = "New\nGame";
        SelectGame(selectedGame);
    }

    private class testSaveObject
    {
        public bool _skill1, _skill2, _skill3;
        public bool tutorial;
        public bool panadera;
        public bool _npc1;
        public bool _npc2;
        public bool _npc3;
    }
}
