using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if (other.TryGetComponent(out PlayerModel player))
        {
            player.BlindPlayer();
        }
    }
}