using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public delegate void OnTaggedChange(string newTagged);

    public event OnTaggedChange onTaggedChange;

    [SerializeField]
    private float playTime = 60F;

    [SerializeField]
    private int playerCount = 4;

    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private bool instantiateHumanPlayer = true;

    [SerializeField]
    private Text currentTag;

    private Dictionary<string, int> taggedScore = new Dictionary<string, int>();

    private GameObject taggedPlayer;

    public GameObject TaggedPlayer { get => taggedPlayer; set => taggedPlayer = value; }

    public string GetWinner()
    {
        return string.Empty;
    }

    // Start is called before the first frame update
    private void Start()
    {
        onTaggedChange += UpdateTaggedScore;

        taggedScore.Clear();

        int tag = Random.Range(0, 3);

        for (int i = 0; i < playerCount; i++)
        {
            string prefabPath = i == 0 && instantiateHumanPlayer ? "HumanPlayer" : "AIPlayer";

            GameObject playerInstance = Instantiate(Resources.Load<GameObject>(prefabPath));
            if(i == 0)
            {
                playerInstance.transform.position = new Vector3(20, -0.5f, 10);
            }
            else if (i == 1)
            {
                playerInstance.transform.position = new Vector3(20, -0.5f, -10);
            }
            else if (i == 2)
            {
                playerInstance.transform.position = new Vector3(-20, -0.5f, -10);
            }
            else if (i == 3)
            {
                playerInstance.transform.position = new Vector3(-20, -0.5f, 10);
            }
            if(i == tag)
            {
                TaggedPlayer = playerInstance;
            }
            playerInstance.name = string.Format("Player{0}", i + 1);

            taggedScore.Add(playerInstance.name, 0);
        }

        Invoke("EndGame", playTime);
    }

    private void Update()
    {
        currentTag.text = taggedPlayer.name;
    }

    private void EndGame()
    {
        onTaggedChange -= UpdateTaggedScore;
    }

    private void UpdateTaggedScore(string newTaggedPlayer)
    {
        taggedScore[newTaggedPlayer] += 1;
    }
}