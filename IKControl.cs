using UnityEngine;
using System;
using System.Collections;

public class IKControl : MonoBehaviour 
{
	// Reference to the animator component
	protected Animator animator;

	// Whether IK is active for the object
	public bool ikActive = false;

	// Whether the object is looking using IK
	public bool looking=false;

	// The transform of the left hand object to move using IK
	public Transform leftHandObj = null;

	// The transform of the object to look at using IK
	private Transform lookObj;

	// Start is called before the first frame update
	private void Start () 
	{
		// Get the animator component
		animator = GetComponent<Animator>();

		// Get the weapon camera object from the player script in the game
		if(Game.instance.playerScript==null) 
			return;

		lookObj = Game.instance.playerScript.weaponCameraObj.transform;
	}

	// Update the IK for the object
	private void OnAnimatorIK()
	{
		if(ikActive) 
		{
			// Update the look target if enabled
			if (looking)
			{
				// Set the weight of the look IK
				animator.SetLookAtWeight (0.6f);//was 0.9f

				// Set the position of the look target
				animator.SetLookAtPosition (lookObj.position);
			}
	
			// Update the left hand IK
			animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,1);
			animator.SetIKRotationWeight(AvatarIKGoal.LeftHand,1);  
			animator.SetIKPosition(AvatarIKGoal.LeftHand,leftHandObj.position);
			animator.SetIKRotation(AvatarIKGoal.LeftHand,leftHandObj.rotation);
		}
	}   
}
