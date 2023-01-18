using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class basicPlayerMovement : MonoBehaviour
{
	[SerializeField]private Rigidbody rb;
	[SerializeField]private float speed;
	[SerializeField]private float jumpForce;
	[SerializeField]private float runSpeed;
	public bool hideMouse;
	[SerializeField]private float sensitivity;
	[SerializeField]private bool flyMode;
	public bool paused;
	public float space;
	public float flySpeed;
	protected void Update()
	{				
		if(paused){
			hideMouse = false;
			Time.timeScale = 0;
			
		}else{hideMouse=true;Time.timeScale = 1;}
		
		if(hideMouse){
			Cursor.lockState = CursorLockMode.Locked; Cursor.visible = false;
		}else{
			Cursor.lockState = CursorLockMode.None; Cursor.visible = true;
		}
		
		if(!paused){
			//movement
			Vector2 movPos= new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
			Vector3 Vel = rb.velocity;
			rb.velocity = (transform.forward * movPos.y + transform.right * movPos.x).normalized * speed;
			rb.velocity = new Vector3(rb.velocity.x,Vel.y, rb.velocity.z);
			
			if(flyMode){
				rb.useGravity = false;
				rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
				if(Input.GetKey(KeyCode.Space)){
					rb.velocity = new Vector3(rb.velocity.x, 1 * flySpeed, rb.velocity.z);
				}
				else if(Input.GetKey(KeyCode.LeftShift)){
					rb.velocity = new Vector3(rb.velocity.x, -1 * flySpeed, rb.velocity.z);
				}
				
			}else{rb.useGravity = true;}
			//rotation
			Vector2 mousePos = new Vector2(Input.GetAxis("Mouse X") * sensitivity, -Input.GetAxis("Mouse Y") * sensitivity);
			transform.Rotate(new Vector3(0,mousePos.x,0));
			Camera.main.transform.Rotate(mousePos.y, 0, 0);
		}
	}
	
	public void mouseHide(bool value){
		if(value){
			Cursor.lockState = CursorLockMode.Locked; Cursor.visible = false;
		}else{
			Cursor.lockState = CursorLockMode.None; Cursor.visible = true;
		}
		
		hideMouse = value;
	}
	public void mouseHide(){
		hideMouse = !hideMouse;
	}
	
	public float boolToFloat(bool value){
		if(value){return 1;}else{return 0;}
	}
	
	
}
