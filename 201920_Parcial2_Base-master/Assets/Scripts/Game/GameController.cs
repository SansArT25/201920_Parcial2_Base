using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static GameController instance;

    private bool playing = true;

    public delegate void OnTaggedChange(string newTagged);

    public event OnTaggedChange onTaggedChange;

    [SerializeField]
    private float playTime = 60F;

    [SerializeField]
    private int playerCount = 4;

    [SerializeField]
    private GameObject playerPrefab, powInv, powRush;

    [SerializeField]
    private bool instantiateHumanPlayer = true;

    [SerializeField] private Material tagged, untagged, invisible;

    private Dictionary<string, int> taggedScore = new Dictionary<string, int>();

    private GameObject taggedPlayer;

    public static GameController Instance
    {
        get { return instance; }
    }

    public GameObject TaggedPlayer { get => taggedPlayer; set => taggedPlayer = value; }
    public Material Untagged { get => untagged; set => untagged = value; }
    public Dictionary<string, int> TaggedScore { get => taggedScore; set => taggedScore = value; }
    public Material Invisible { get => invisible; set => invisible = value; }
    public bool Playing { get => playing; set => playing = value; }

    public string GetWinner()
    {
        return string.Empty;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
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
                playerInstance.GetComponent<NavMeshAgent>().Warp(new Vector3(-15, 1, 8));
            }
            else if (i == 1)
            {
                playerInstance.GetComponent<NavMeshAgent>().Warp(new Vector3(15, 1, 8));
            }
            else if (i == 2)
            {
                playerInstance.GetComponent<NavMeshAgent>().Warp(new Vector3(-15, 1, -8));
            }
            else if (i == 3)
            {
                playerInstance.GetComponent<NavMeshAgent>().Warp(new Vector3(15, 1, -8));
            }
            if(i == tag)
            {
                taggedPlayer = playerInstance;
                playerInstance.GetComponent<Renderer>().material = tagged;
                playerInstance.GetComponent<PlayerController>().IsTagged = true;
            }
            playerInstance.name = string.Format("Player{0}", i + 1);

            taggedScore.Add(playerInstance.name, 0);
        }

        GameObject pow = Instantiate(powInv);
        pow.transform.position = new Vector3(Random.Range(-16, 16), 0.371875f, Random.Range(-8, 8));

        pow = Instantiate(powInv);
        pow.transform.position = new Vector3(Random.Range(-16, 16), 0.371875f, Random.Range(-8, 8));

        pow = Instantiate(powRush);
        pow.transform.position = new Vector3(Random.Range(-16, 16), 0.371875f, Random.Range(-8, 8));

        pow = Instantiate(powRush);
        pow.transform.position = new Vector3(Random.Range(-16, 16), 0.371875f, Random.Range(-8, 8));

        taggedScore[taggedPlayer.name] += 1;

        Invoke("EndGame", playTime);
    }

    private void EndGame()
    {
        onTaggedChange -= UpdateTaggedScore;
        for(int i =0; i < 4; i++)
        {
            GameObject.FindGameObjectWithTag("Player").SetActive(false);
        }
        playing = false;
    }

    public void Tag(GameObject player)
    {
        taggedPlayer.GetComponent<Renderer>().material = untagged;
        UpdateTaggedScore(player.name);
        taggedPlayer = player;
        player.GetComponent<Renderer>().material = tagged;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private void UpdateTaggedScore(string newTaggedPlayer)
    {
        taggedScore[newTaggedPlayer] += 1;
    }
}