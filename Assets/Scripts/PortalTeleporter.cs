/**
 * This script will check if the player has entered the right side of the
 * portal, and if they do, it will teleport them to the other side.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour {

	public Transform player; // Reference to the player
	public Transform reciever; // Reference to the receiving portal

	private bool playerOverlap = false; // Boolean to store if player and box collider collide.

	// Update is called once per frame
	void Update () {
		if (playerOverlap)
		{
			Vector3 portalToPlayer = player.position - transform.position; // Distance between player and portal
			float dotProduct = Vector3.Dot(transform.up, portalToPlayer); // The dot product betweeen V3.up and the p2p (EXPLAINED BELOW)
			print("HIII");
			/**
			 * <<<<<EXPLANATION ON HOW DOT PRODUCT WORKS>>>>
			 * sorry for my casual explananation... buttttttt (plz don't fire me)
			 * so basically, to tell whether the player is entering from behind or the 
			 * right side of the portal, you take the dot product, and check if it's negative or not.
			 * Basically, you're finding the value of Cos(up - the player's position from the object).
			 * If you recall in basic functions, in quadrant 2 and 3, the value of cos(theta) is 
			 * negative. So therefore, when you're entering from the wrong side, the dot product will
			 * be positive since the angle it forms with the object will be between -pi/2 and pi/2 
			 * radians, where it is positive. If it's negative, that means youre forming an angle
			 * between pi/2 and 3pi/2 radians, which is the correct side.
			 * 
			 * Sorry if you didn't understand my explaination. If you really want me to explain
			 * This script / unity program, email me at billbai0102@gmail.com and i'll skype you or something...
			 */ 
			if (dotProduct < 0f)
			{
				// Teleport the player
				float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
				rotationDiff += 180;
				player.Rotate(Vector3.up, rotationDiff);

				Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
				player.position = reciever.position + positionOffset;

				playerOverlap = false;
			}
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "New tag") // << To whoever is reading my comments (who even does that??)
		{							// sorry for naming the tag "New tag" i honestly couldn't
									// find out how to change the tag name. lol.
			playerOverlap = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.tag == "New tag")
		{
			playerOverlap = false;
		}
	}
}
