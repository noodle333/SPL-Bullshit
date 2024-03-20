using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float timeToMove = .1f;
    [SerializeField] private LayerMask collisionLayer;
    private bool isMoving = false;

    private bool canMove = false;
    private bool restartGame = true;

    private void Start()
    {
        StartCoroutine(EnableRestartGame());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !restartGame)
        {
            canMove = false;
            restartGame = true;
            FindObjectOfType<SceneLoader>().StartLoadSceneMenu(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

        if (!isMoving && canMove)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                StartCoroutine(Move(Vector2.up));
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                StartCoroutine(Move(Vector2.left));
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                StartCoroutine(Move(Vector2.down));
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                StartCoroutine(Move(Vector2.right));
            }
        }
    }

    private IEnumerator EnableRestartGame()
    {
        yield return new WaitForSeconds(1.5f);
        restartGame = false;
        canMove = true;
    }

    private IEnumerator Move(Vector2 dir)
    {
        //prevent player from forcing through colliders.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1f, collisionLayer);
        if (hit)
        {
            BoxMovement box = hit.collider.GetComponent<BoxMovement>();
            if (box != null)
            {
                RaycastHit2D h = Physics2D.Raycast(box.transform.position + new Vector3(dir.x, dir.y, 0) * 0.6f, dir, .5f, collisionLayer);
                Debug.DrawRay(box.transform.position, dir * 1f, Color.red, 2f);

                if (h)
                {
                    yield break;
                }
                StartCoroutine(box.Move(dir));
            }
            else
            {
                yield break;
            }
        }

        isMoving = true;
        Vector2 pos = transform.position;
        Vector2 target = pos + dir;
        float time = 0;
        while (time < timeToMove)
        {
            time += Time.deltaTime;
            float t = time / timeToMove;
            transform.position = Vector2.Lerp(pos, target, t);
            yield return null;
        }
        transform.position = target;

        isMoving = false;
    }
}
