using UnityEngine;

public class Algae : Obstacles
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerModel>(out PlayerModel player))
        {
            Debug.Log($"Entered into algae {other.gameObject}");
            player.WeakePlayer();
        }
    }
}