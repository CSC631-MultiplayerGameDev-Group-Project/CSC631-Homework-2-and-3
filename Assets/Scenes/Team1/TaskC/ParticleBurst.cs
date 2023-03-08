using UnityEngine;

public class ParticleBurst : MonoBehaviour
{
    public ParticleSystem collisionParticleSystem;
    public MeshRenderer mr;
    public bool once = true;
    
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player") && once) {
            var em = collisionParticleSystem.emission;
            var dur = collisionParticleSystem.duration;

            em.enabled = true;
            collisionParticleSystem.Play();

            once = false;
            Destroy(mr);
            Invoke(nameof(DestroyObj), dur);
        }
    }

    void DestroyObj() {
        Destroy(gameObject);
    }
}
