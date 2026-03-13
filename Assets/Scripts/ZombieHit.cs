using UnityEngine;

public class ZombieHit : MonoBehaviour
{
    Animator animator;
    Rigidbody[] ragdollBodies;
    UnityEngine.AI.NavMeshAgent agent;
    public ZombieManager manager;

    public bool isDead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();

        ragdollBodies = GetComponentsInChildren<Rigidbody>();

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        foreach(Rigidbody rb in ragdollBodies){
            rb.isKinematic = true;
        }
    }

    // Collision with car
    void OnCollisionEnter(Collision collision)
    {
        // I have used 3 colliders in zombie so this is needed
        if(isDead) return;

        // Only if car hits
        if(collision.gameObject.CompareTag("Car")){
            CapsuleCollider capsule = GetComponent<CapsuleCollider>();

            if(capsule != null){
                capsule.enabled = false;
            }

            ScoreManager.instance.AddPoints();
            isDead = true;

            // Nav Mesh agent inactivates
            if(agent != null) agent.enabled = false;

            // Zombie animation ends
            if(animator != null){
                animator.SetBool("Hit", true);
                animator.enabled = false;
            }
            
            Vector3 force = collision.relativeVelocity; 

            // Ragdoll reaction activates
            foreach(Rigidbody rb in ragdollBodies){
                rb.isKinematic = false;
                rb.AddForce(force, ForceMode.Impulse);
            }

            
            if(manager != null){
                manager.Respwan(this.gameObject);
            }
        }
    }

    // After respawning the zombie in arena, we need to active components
    public void ResetZombie(Vector3 position){
        transform.position = position;

        // Inactivate unessecary physics for ragdoll, improves performance
        foreach(Rigidbody ragdoll in ragdollBodies){
            ragdoll.linearVelocity = Vector3.zero;
            ragdoll.angularVelocity = Vector3.zero;
            ragdoll.isKinematic = true;
        }
        
        // But activate collider
        CapsuleCollider capsule = gameObject.GetComponent<CapsuleCollider>();
        if(capsule != null){
            capsule.enabled = true;
        }

        // Activates nav agent
        if(agent != null){
            agent.enabled = true;
        }

        // Activates animation
        if(animator != null){
            animator.enabled = true;
            animator.SetBool("Hit", false);
        }
        
        // Mark as not dead
        isDead = false;
    }
}
