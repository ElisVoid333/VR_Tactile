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