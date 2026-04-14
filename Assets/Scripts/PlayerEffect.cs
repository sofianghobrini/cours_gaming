using UnityEngine;
using System.Collections;
public class PlayerEffect : MonoBehaviour
{
    public void AddSpeed(float speedIncrease, float duration)
    {
        PlayerMovement.instance.moveSpeed += speedIncrease;
        StartCoroutine(RemoveSpeed(speedIncrease, duration));
    }

    private IEnumerator RemoveSpeed(float speedIncrease, float duration)
    {
        yield return new WaitForSeconds(duration);
        PlayerMovement.instance.moveSpeed -= speedIncrease;
    }
}
