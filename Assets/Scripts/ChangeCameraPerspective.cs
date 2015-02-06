using UnityEngine;
using System.Collections;

public class ChangeCameraPerspective : MonoBehaviour {
	//public Transform target;
	public Camera multiviewCamera;
	public Light directionalLight;
	//public Camera cam2;
	public float smoothTime = 0.3f;
	public float rotateSpeed = 0.1f;
	private Vector3 target3D = new Vector3(4.5f, -1.23f, -10.13f);
	private Vector3 target2D = new Vector3(5.0f, 8.5f, -17.5f);
	private Quaternion target3DQuat = new Quaternion(-0.3f, 0, 0, 1.0f);
	private Quaternion target2DQuat = Quaternion.identity;
	private Vector3 velocity = Vector3.zero;
	private bool is2D = false;
	private bool is3D = true;
	private bool isTransferring2D = false;
	private bool isTransferring3D = false;
	public void TransferViews(){
		if(is2D){
			// I want to transfer to 3D
			isTransferring3D = true;
		}
		else{
			// I wnt to transfer to 2D
			isTransferring2D = true;
		}
	}
	void Update () {
		// if I'm transfering to 2D && am in 3D mode do
		if(is3D && isTransferring2D){
			if(CompareVec3(transform.position, target2D)){
				multiviewCamera.orthographic = true;
				isTransferring2D = false;
				is3D = false;
				is2D = true;
			}
			directionalLight.shadows = LightShadows.None;
			transform.position = Vector3.SmoothDamp(transform.position, target2D, ref velocity, smoothTime);
			transform.rotation = Quaternion.Slerp(transform.rotation, target2DQuat, rotateSpeed);
		}
		else if(is2D && isTransferring3D){
			// if i'm transfering to 3d && am in 2D mode do
			if(CompareVec3(transform.position, target3D)){

				isTransferring3D = false;
				is3D = true;
				is2D = false;
			}
			directionalLight.shadows = LightShadows.Hard;
			multiviewCamera.orthographic = false;
			transform.position = Vector3.SmoothDamp(transform.position, target3D, ref velocity, smoothTime);
			transform.rotation = Quaternion.Slerp(transform.rotation, target3DQuat, smoothTime);
		}
	}
	private bool CompareVec3(Vector3 vec1, Vector3 vec2){
		if(CompareFloat(vec1.x, vec2.x) && CompareFloat(vec1.y, vec2.y) && CompareFloat(vec1.z, vec2.z)){
			return true;
		}
		return false;
	}
	private bool CompareFloat(float a, float b){
			return Mathf.Abs(a - b)< 0.001 ? true: false;
	}

}
