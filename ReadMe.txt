This project is used to test how people respond to different interaction methods.
There is a desk with a mug and on the left side and the user is meant to try picking it up and placing it on the plane to their 
right on the desk.

The first Condition is a bare hand interaction using hand tracking. The User uses their bare hands to interact with 
the mug on the desk and pick it up to place it on the target. The Hand tracking should be enabled by placing the controllers 
on the desk and moving your hands in front of the headset until it triggers and your virtual hands appear.

The Second Condition is an interaction using a physical mug. A controller/tracker is fixed to a real mug which lines up with 
a virtual mug model. The user is meant to use their bare hands to pick up the physical mug and place it on the target. 

The Third Condition is using the controllers to interact with the virtual mug. The controllers will have hand models attached 
so they appear the same as your virtual hands. The user will use the controllers to pick up and move the virtual mug onto the 
target.

The Third Condition is using the controllers that provide haptic feedback to interact with the virtual mug. The controllers 
will provide some vibrotactile feedback when the user comes in contact with the mug and when they pick it up. The user will 
use the controllers to pick up and move the virtual mug onto the target.


To toggle between left controller mug and left controller hand.
Go to the heirarchy:

OVRCamerRig
	OVRInteraction
		OVRControllerHands
			OVRLeftHandSynthetic - AND MUG
				OVRLeftHandVisual
					OculusHand_L

To make hand active turn on b_l_wrist and l_handMeshNode, turn off BlueMug.

To make Mug active turn on BlueMug, turn off b_l_wrist and l_handMeshNode.


To togle the grab function on the left controller if you don't want the user to be able to grab things with the Blue mug active.

Go to the hierarchy:

OVRCamerRig
	OVRInteraction
		OVRControllerHands
			LeftControllerHand
				ControllerHandInteractors

To turn on the grab functions make HandPokeInteractor and HandGrabInteractor active.

To turn off the grab functions make HandPokeInteractor and HandGrabInteractor inactive.


Hand Tracking should be Enabled if it is enabled in the headset settings. The Black Mug should be grabbable with hand tracking.


To toggle the haptic feedback on the blue mug.
Go to the hierarchy:

Interactables
	BlackMug

To turn off haptic feedback make pointable Unity Event Wrapper inactive.

To turn on haptic feedback make pointable Unity Event Wrapper active.