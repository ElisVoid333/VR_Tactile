# VR Tactile Test #
To run the scene, open the project in the correct Unity version and open the scene Assets/VRexperiment/VRSeriousTest-v11. 
The left controller should be attached to a mug. There should be a set of image in the project that show the controllers
intended orientation in the mug.

Hacked together with the following assets for Prof. Teather's VR class Winter 2023
Rodolfo Cossovich
Andrew Thompson
Shagha Kalantari

And later update by Jay Henderson and Elis Joynes.

## Tech requirements:
    - Unity 2021.3.21f1 with an Oculus Quest 2 (Dev mode) to run tethered
    - Oculus XR Plugin 3.2.3
    - OpenXR Plugin 1.6.0
    - XR Hands 1.1.0
    - XR Interaction Toolkit 2.3.0 with Starter Assets and Hands Interaction Demo samples installed 
    - XR Hands 1.1.0 with HandVisualizer sample installed
    - TextMeshPro 3.06
    - Ardity 1.1.0 (unused in the latest version)

The project only works when plugged in and run in rift mode with a quest. The haptic feedback works best this way. And the Data logging can be managed.

## Description ##
This project is used to test how people respond to different interaction methods.
There is a desk with a mug and on the left side and the user is meant to try picking it up and placing it on the plane to 
their right on the desk.

The First cCondition is a bare hand interaction using hand tracking. The User uses their bare hands to interact with 
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

## Data Logs Management ##
The Data logging is handled by the Logger GameObject in the OVRCamerRig. Each script component is responsible for a tracked 
gameObject, BlackMug, BlueMug, RightController, LeftHand, RightHand. The log files for these get dumped to LoggedFiles. 
The files don't get overwritten, they just add the data to the already existing file and seperate it with a new header line.
Before each Log session make sure there are no pre existing log files and if there are and they are important put them into 
a folder within the LoggedFiles folder. After each Log session put the log files in a folder and properly label it so you 
don't lose track of the data.

## To Change Conditions ##
To toggle between left controller mug and left controller hand.
Go to the heirarchy:

OVRCamerRig
	OVRInteraction
		OVRControllerHands
			OVRLeftHandSynthetic - AND MUG
				OVRLeftHandVisual
					OculusHand_L

To make Hand active turn on b_l_wrist and l_handMeshNode, turn off BlueMug.

To make Mug active turn on BlueMug, turn off b_l_wrist and l_handMeshNode.


To toggle the grab function on the left controller if you don't want the user to be able to grab things with the Blue mug active.

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