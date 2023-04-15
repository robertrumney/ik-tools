using UnityEngine;
using System.Collections;

public class NPCLookIK : MonoBehaviour 
{
    // The animator component of the NPC
    private Animator anim;

    // The target that the NPC should look at
    public Transform target;

    // The ragdoll objects and gore object for the NPC
    public GameObject[] ragdolls;
    public GameObject gore;

    // The weight values for the IK solver
    public float weight = 1.00f;
    public float bodyWeight = 1.00f;
    public float headWeight = 1.00f;
    public float eyesWeight = 0.00f;
    public float clampWeight = 0.50f;

    // Options to control the NPC behavior
    public bool onlyFromDistance = false;
    public bool findPlayer = false;
    public float distance;

    // States to keep track of NPC behavior
    private bool looking = true;
    private bool ragdoll = false;

    // Initialize the NPC
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        // Find the player object as the target if specified
        if (findPlayer)
        {
            target = Game.instance.playerScript.weaponCameraObj.transform;
        }

        // Start checking distance between the NPC and the target if specified
        if (onlyFromDistance)
        {
            StartCoroutine(DistanceCheck());
        }
    }

    // Handle NPC damage
    private void PlayaDamage()
    {
        // Replace the NPC model with a ragdoll if gore object is specified
        if (gore)
        {
            if (!ragdoll)
            {
                RagDoll();
                ragdoll = true;
            }
        }
    }

    // Replace the NPC model with a ragdoll object
    private void RagDoll()
    {
        anim.enabled = false;
        (GetComponent<Collider>() as CapsuleCollider).enabled = false;
        Destroy(GetComponent<Rigidbody>());
        for (int i = 0; i < ragdolls.Length; i++)
        {
            Instantiate(gore, ragdolls[i].transform.position, ragdolls[i].transform.rotation);
        }
    }

    // Set the target for the NPC to look at
    private void SetTarget(Transform x)
    {
        target = x;
    }

    // Start checking distance between the NPC and the target
    IEnumerator DistanceCheck()
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, target.position) < distance)
            {
                looking = true;
            }
            else
            {
                looking = false;
            }

            yield return null;
        }
    }

    // Update the IK weights of the NPC
    private void OnAnimatorIK(int layerIndex)
    {
        if (target && looking)
        {
            // Set the target position for the NPC to look at
            anim.SetLookAtPosition(target.position);

            // Set the IK weights for the NPC
            anim.SetLookAtWeight(weight, bodyWeight, headWeight, eyesWeight, clampWeight);
        }
    }
}
