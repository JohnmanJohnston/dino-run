using UnityEngine;
using System.Collections;

public class ObstacleGen : MonoBehaviour
{
    [SerializeField] private float MovingSpeed;
    [SerializeField] private GameObject Obstacle;
    [SerializeField] private Vector2 SpawnPosition;
    [SerializeField] private float ResetValue;

    private void Start() {
        StartCoroutine(IncreaseMovingSpeed());
        Obstacle.transform.position = SpawnPosition;
    }

    private IEnumerator IncreaseMovingSpeed() {
        yield return new WaitForSeconds(2f);
        MovingSpeed += 0.2f;
        StartCoroutine(IncreaseMovingSpeed());
    }      

    private void Update() {
        Obstacle.transform.position += new Vector3((MovingSpeed * Time.deltaTime) * -1f, 0f, 0f);

        if (Obstacle.transform.position.x < ResetValue) {
            Obstacle.transform.position = SpawnPosition;
        }
    }
}
