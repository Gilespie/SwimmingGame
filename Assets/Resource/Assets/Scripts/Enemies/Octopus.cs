using UnityEngine;

public class Octopus : MonoBehaviour
{
    [SerializeField] private float detectionRadius = 2.5f;
    [SerializeField] private float _rotationSpeed = 1.0f;
    [SerializeField] private float reactionTime = 1.5f;
    [SerializeField] private float cooldownTime = 2f;
    [SerializeField] private ParticleSystem _shootPrefab;
    [SerializeField] private LayerMask _playerLayer;
    private Transform _target;
    private bool isOnCooldown = false;
    private float timeSinceLastAttack = 0f;
    private bool _hasShot = false;

    void Update()
    {
        HandleCooldown();
        FindPlayer();
        RotateObject();
    }

    private void HandleCooldown()
    {
        if (isOnCooldown)
        {
            timeSinceLastAttack += Time.deltaTime;

            if (timeSinceLastAttack >= cooldownTime)
            {
                isOnCooldown = false;
                timeSinceLastAttack = 0f;
                _hasShot = false;
            }
        }
    }

    private void FindPlayer()
    {
        if (isOnCooldown || _hasShot) return;

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, _playerLayer);

        if (hitColliders.Length > 0)
        {
            _target = hitColliders[0].transform;
            Invoke(nameof(ShootInk), reactionTime);
            isOnCooldown = true;
            _hasShot = true;
        }
        else
        {
            _target = null;
        }
    }

    private void ShootInk()
    {
        if (_target != null)
        {
            _shootPrefab.Play();
        }
    }
    private void RotateObject()
    {
        if (_target == null) return;

        Vector3 dir = (_target.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

}