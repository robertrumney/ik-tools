using UnityEngine;

public class HoldIK : MonoBehaviour 
{
	// Reference to the animator component
	protected Animator animator;

	// Whether IK is active for the object
	public bool ikActive = false;

	// The transform of the right hand object to move using IK
	public Transform rightHandObj = null;

	// The transform of the left hand object to move using IK
	public Transform leftHandObj = null;

	// Start is called before the first frame update
	private void Start () 
	{
		// Get the animator component
		animator = GetComponent<Animator>();
	}

	// Update the IK for the object's hands
	private void OnAnimatorIK()
	{
		if(ikActive) 
		{
			// Update the left hand IK
			animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
			animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
			animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandObj.position);
			animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandObj.rotation);

			// Update the right hand IK
			animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
			animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);  
			animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandObj.position);
			animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandObj.rotation);
		}
	}   
}
