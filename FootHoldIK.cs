using UnityEngine;

public class FootHoldIK : MonoBehaviour 
{
    // Public boolean variable indicating whether the IK system is active or not
    public bool ikActive = false;

    // Public Transform variables representing the target positions for the character's feet
    public Transform rightFootObj = null;
    public Transform leftFootObj = null;

    // Private Animator variable for accessing the Animator component on this GameObject
    private Animator animator;

    private void Start () 
    {
        // Get the Animator component on this GameObject
        animator = GetComponent<Animator>();
    }
        
    private void OnAnimatorIK()
    {
        if(ikActive) 
        {
            // Set the weight of the IK solver for the left foot to 1
            animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot,1);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot,1);  

            // Set the position and rotation of the left foot to the position and rotation of the leftFootObj Transform
            animator.SetIKPosition(AvatarIKGoal.LeftFoot,leftFootObj.position);
            animator.SetIKRotation(AvatarIKGoal.LeftFoot,leftFootObj.rotation);

            // Set the weight of the IK solver for the right foot to 1
            animator.SetIKPositionWeight(AvatarIKGoal.RightFoot,1);
            animator.SetIKRotationWeight(AvatarIKGoal.RightFoot,1);  

            // Set the position and rotation of the right foot to the position and rotation of the rightFootObj Transform
            animator.SetIKPosition(AvatarIKGoal.RightFoot,rightFootObj.position);
            animator.SetIKRotation(AvatarIKGoal.RightFoot,rightFootObj.rotation);
        }
    }   
}
