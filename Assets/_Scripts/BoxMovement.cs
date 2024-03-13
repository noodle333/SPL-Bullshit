using System.Collections;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField] private float timeToMove = .1f;
    [SerializeField] private LayerMask collisionLayer;
    private bool isMoving = false;

    public IEnumerator Move(Vector2 dir)
    {
        if (isMoving) yield break;
        isMoving = true;
        Vector2 startPos = transform.position;
        Vector2 endPos = startPos + dir;

        float elapsedTime = 0;
        while (elapsedTime < timeToMove)
        {
            elapsedTime += Time.deltaTime;
            transform.position = Vector2.Lerp(startPos, endPos, elapsedTime / timeToMove);
            yield return null;
        }

        transform.position = endPos;
        isMoving = false;
    }
}
