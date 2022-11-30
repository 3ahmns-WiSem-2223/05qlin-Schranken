using UnityEngine;

public class Manager : MonoBehaviour
{
    bool openE;
    bool openZ;
    bool playerMoveZiel = true;
    bool playerFaceRight = true;
    [SerializeField] private GameObject schrankeE;
    [SerializeField] private GameObject schrankeZ;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ziel;
    float speed = 5f;
    Vector2 playerPos;

    private void Start()
    {
        player.GetComponent<Animator>().enabled = false;
        playerPos = player.transform.position;
        player.GetComponent<AudioSource>().enabled = false;
    }
    public void OpenSchrankeE()
    {
        if (openE == false)
        {
            schrankeE.transform.position = new Vector2(-2, -3);
            openE = true;
        }
        else
        {
            openE = false;
            schrankeE.transform.position = new Vector2(-2, -2f);
        }
    }

    public void OpenSchrankeZ()
    {
        if (openZ == false)
        {
            openZ = true;
            schrankeZ.transform.position = new Vector2(2, -3);
        }
        else
        {
            openZ = false;
            schrankeZ.transform.position = new Vector2(2, -2f);
        }
    }

    private void MovePlayer()
    {
        if (openE == true && openZ == true)
        {
            if (playerMoveZiel == true)
            {
                player.GetComponent<Animator>().enabled = true;
                player.GetComponent<AudioSource>().enabled = true;
                player.transform.position = Vector2.MoveTowards(player.transform.position, ziel.transform.position, speed * Time.deltaTime);

                if (playerFaceRight == false)
                    player.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                player.GetComponent<Animator>().enabled = true;
                player.GetComponent<AudioSource>().enabled = true;
                player.transform.position = Vector2.MoveTowards(player.transform.position, playerPos, speed * Time.deltaTime);

                if (playerFaceRight == true)
                    player.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        else
        {
            player.GetComponent<Animator>().enabled = false;
            player.GetComponent<AudioSource>().enabled = false;

            if (playerMoveZiel == true)
                player.transform.position = playerPos;
            else
                player.transform.position = ziel.transform.position;
        }

    }

    private void Update()
    {
        MovePlayer();

        if (player.transform.position.x == ziel.transform.position.x)
        {
            playerMoveZiel = false;
            playerFaceRight = true;
        }
        else if (player.transform.position.x == playerPos.x)
        {
            playerMoveZiel = true;
            playerFaceRight = false;
        }
    }
}

