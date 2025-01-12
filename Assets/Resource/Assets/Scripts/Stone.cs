using UnityEngine;

public class Stone : Obstacles
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<PlayerModel>(out PlayerModel player))
        {
            Debug.Log($"Entered into stone {other.gameObject}");
            player.StunPlayer();
        }
    }
}
