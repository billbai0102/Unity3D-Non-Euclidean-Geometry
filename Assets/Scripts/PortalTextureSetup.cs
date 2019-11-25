using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour {

	public Camera cameraB; // reference to camera B
	public Camera cameraA; // reference to camera A
	
	public Material cameraMatB; // reference to camera B's material
	public Material cameraMatA; // reference to camera A's material

	void Start() {
		// Checks if camera B already has a render texture
		if(cameraB.targetTexture != null){
			cameraB.targetTexture.Release(); // Remove the texture
		}
		cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24); // Create new render texturefor B
		cameraMatB.mainTexture = cameraB.targetTexture; // Sets B's main texture to it's render texture.// Checks if camera B already has a render texture

		if(cameraA.targetTexture != null){
			cameraA.targetTexture.Release(); // Remove the texture
		}
		cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24); // Create new render texturefor A
		cameraMatA.mainTexture = cameraA.targetTexture; // Sets A's main texture to it's render texture.
	}
	
}
