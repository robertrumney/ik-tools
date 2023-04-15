using UnityEngine;

public class Foot_IK : MonoBehaviour
{
    // Whether IK is active or not
    public bool IkActive = true;

    // The weight of right foot position
    [Range(0f, 1f)]
    public float WeightPositionRight = 1f;

    // The weight of right foot rotation
    [Range(0f, 1f)]
    public float WeightRotationRight = 0f;

    // The weight of left foot position
    [Range(0f, 1f)]
    public float WeightPositionLeft = 1f;

    // The weight of left foot rotation
    [Range(0f, 1f)]
    public float WeightRotationLeft = 0f;

    // Reference to the Animator component
    Animator anim;

    // Offset for Foot position
    [Tooltip("Offset for Foot position")]
    public Vector3 offsetFoot;

    // The offset for right foot position
    public Vector3 offsetFootRight;

    // The offset for left foot position
    public Vector3 offsetFootLeft;

    // The layer where foot can adjust to surface
    [Tooltip("Layer where foot can adjust to surface")]
    public LayerMask RayMask;

    // The RaycastHit used to get information about the ground
    private RaycastHit hit;

    // The default offset for right foot position
    private Vector3 _offsetFootRight = new Vector3(0, 0.15f, 0);

    // The default offset for left foot position
    private Vector3 _offsetFootLeft = new Vector3(0, 0.15f, 0);

    // The speed used to calculate foot offsets
    private int strideLength = 0;

    private void Awake()
    {
        // Set a random stride length
        strideLength = Random.Range(8, 12);
    }

    private void Start()
    {
        // Get a reference to the Animator component
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        // Update the right foot offset based on the current stride length
        offsetFootRight = (this.transform.right / strideLength) + _offsetFootRight;

        // Update the left foot offset based on the current stride length
        offsetFootLeft = (-this.transform.right / strideLength) + _offsetFootLeft;
    }

    private void OnAnimatorIK(int _layerIndex)
    {
        if (IkActive)
        {
            // Get the current position of the right foot
            Vector3 FootPos = anim.GetIKPosition(AvatarIKGoal.RightFoot);

            // Throw a raycast down to get information about the ground
            if (Physics.Raycast(FootPos + Vector3.up, Vector3.down, out hit, 1.2f, RayMask))
            {
                // Set the weight of the right foot position
                anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, WeightPositionRight);

                // Set the weight of the right foot rotation
                anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, WeightRotationRight);

                // Set the position of the right foot to where the raycast hit, with an offset
                anim.SetIKPosition(AvatarIKGoal.RightFoot, hit.point + offsetFootRight);

                if (WeightRotationRight > 0f)
                {
                    // Calculate the rotation of the right foot based on the ground normal
                    Quaternion footRotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, hit.normal), hit.normal);

                    // Set the rotation of the right foot
                    anim                    .SetIKRotation(AvatarIKGoal.RightFoot, footRotation);
                }
            }
            else // If the raycast doesn't hit anything, keep the original position and rotation
            {
                anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0f);
                anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, 0f);
            }

            // Get the current position of the left foot
            FootPos = anim.GetIKPosition(AvatarIKGoal.LeftFoot);

            // Throw a raycast down to get information about the ground
            if (Physics.Raycast(FootPos + Vector3.up, Vector3.down, out hit, 1.2f, RayMask))
            {
                // Set the weight of the left foot position
                anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, WeightPositionLeft);

                // Set the weight of the left foot rotation
                anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, WeightRotationLeft);

                // Set the position of the left foot to where the raycast hit, with an offset
                anim.SetIKPosition(AvatarIKGoal.LeftFoot, hit.point + offsetFootLeft);

                if (WeightRotationLeft > 0f)
                {
                    // Calculate the rotation of the left foot based on the ground normal
                    Quaternion footRotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, hit.normal), hit.normal);

                    // Set the rotation of the left foot
                    anim.SetIKRotation(AvatarIKGoal.LeftFoot, footRotation);
                }
            }
            // If the raycast doesn't hit anything, keep the original position and rotation
            else 
            {
                anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0f);
                anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 0f);
            }
        }
        // If IK is not active, set all weights to 0
        else
        {
            anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0f);
            anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, 0f);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0f);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 0f);
        }
    } 
}
