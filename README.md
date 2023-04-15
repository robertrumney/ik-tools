# ik-tools
Inverse Kinematics toolset for Unity C# allowing better NPC interactions for holding and looking.

## NPCLookIK 
This is a C# script for an NPC (non-player character) in Unity that uses Inverse Kinematics (IK) to control the character's looking behavior. The script defines an NPC's target and applies IK weights to various body parts to ensure the character's gaze follows the target smoothly.

The script also includes options to control the NPC's behavior based on the distance between the NPC and its target. For example, the "onlyFromDistance" option limits the NPC's looking behavior to a certain distance from the target.

Additionally, the script includes a "RagDoll" method that disables the NPC's rigidbody and collider and replaces the character model with a gore object when the NPC takes damage.

## IKControl
This is a C# script for controlling the inverse kinematics (IK) of an object in Unity. Specifically, the script sets the position and rotation of the left hand of an object using IK, and can also set the look target of the object using IK.

The script uses the Animator component of the object to set the IK weights and target positions. If "looking" is enabled, the script sets the look weight to 0.6 and the look position to the position of "lookObj," which is set to the weapon camera of the player script in the game.

If "ikActive" is enabled, the script sets the IK position and rotation of the left hand of the object to the position and rotation of "leftHandObj," respectively.

## HoldIK
The script uses the Animator component of the object to set the IK weights and target positions. If "ikActive" is enabled, the script sets the IK position and rotation of the left and right hands of the object to the positions and rotations of "leftHandObj" and "rightHandObj," respectively.

Overall, this script provides a simple and flexible way to control the IK of an object's hands in Unity.

However, the script lacks comments that could help to explain the purpose and functionality of each section of code. Adding comments to the code would make it easier to understand for other developers.

## FootIK

This script is for implementing inverse kinematics (IK) for the feet of a humanoid character in Unity. It allows the feet to adjust to the surface they are walking on by using a raycast to determine the surface height and orientation.

#### Public variables

- `IkActive`: a boolean that enables or disables the IK.
- `WeightPositionRight`, `WeightRotationRight`, `WeightPositionLeft`, and `WeightRotationLeft`: floats that control the weight of the position and rotation of the feet.
- `offsetFoot`: a vector3 that adjusts the position of both feet.
- `offsetFootRight` and `offsetFootLeft`: vectors3 that adjust the position of the right and left feet respectively.
- `RayMask`: a layer mask that determines what objects the raycast can hit.

#### Private variables and functions

- `anim`: a reference to the Animator component.
- `hit`: a RaycastHit that stores information about the surface the raycast hit.
- `_offsetFootRight` and `_offsetFootLeft`: default offset vectors for the right and left feet respectively.
- `strideLength`: an integer that determines the length of the stride for the feet.
- `Awake()`: a function that sets a random stride length.
- `Start()`: a function that gets a reference to the Animator component.
- `Update()`: a function that updates the `offsetFootRight` and `offsetFootLeft` based on the current stride length.
- `OnAnimatorIK()`: a function that updates the position and rotation of the feet using IK based on the weight variables and the raycast hit information.

Overall, this script provides a simple and effective way to implement IK for the feet of a humanoid character in Unity. It allows for realistic adjustments to the feet when walking on uneven surfaces, which can greatly enhance the immersion of a game or simulation.
