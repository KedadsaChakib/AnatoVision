using UnityEngine;
using System.Collections;

public class MoveDownWithSeparation : MonoBehaviour
{
    public float moveDistance = 0.2f; // Distance de déplacement vers le bas
    public float separationDistance = 0.2f; // Distance de séparation
    public float maxMoveDistance = 1.0f; // Limite maximale de déplacement
    public float duration = 2.0f; // Durée du déplacement
    public float moveDistanceLeft = 0.1f; // Distance de déplacement vers la gauche
    public float moveDistanceRight = 0.1f; // Distance de déplacement vers la droite
    public bool moveLeft = false; // Indicateur de déplacement vers la gauche
    public bool moveRight = false; // Indicateur de déplacement vers la droite

    private Vector3 originalPosition;
    private bool moved = false;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    public void Move()
    {
        if (!moved)
        {
            Vector3 targetPosition = originalPosition - new Vector3(0, moveDistance, 0) - transform.up * separationDistance;
            if (moveLeft)
            {
                targetPosition += Vector3.left * moveDistanceLeft;
            }
            else if (moveRight)
            {
                targetPosition += Vector3.right * moveDistanceRight;
            }
            targetPosition = ClampToMaxDistance(targetPosition);
            StartCoroutine(MoveToPosition(targetPosition, duration));
            moved = true;
        }
        else
        {
            StartCoroutine(MoveToPosition(originalPosition, duration));
            moved = false;
        }
    }

    private IEnumerator MoveToPosition(Vector3 target, float duration)
    {
        float elapsedTime = 0;
        Vector3 startingPos = transform.localPosition;
        while (elapsedTime < duration)
        {
            transform.localPosition = Vector3.Lerp(startingPos, target, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = target;
    }

    private Vector3 ClampToMaxDistance(Vector3 targetPosition)
    {
        float distance = Vector3.Distance(originalPosition, targetPosition);
        if (distance > maxMoveDistance)
        {
            Vector3 direction = (targetPosition - originalPosition).normalized;
            targetPosition = originalPosition + direction * maxMoveDistance;
        }
        return targetPosition;
    }
}
