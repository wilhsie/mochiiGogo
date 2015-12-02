using UnityEngine;
using System.Collections;

public class platformController : MonoBehaviour {

	public GameObject platform;
	public GameObject player;
	private GameObject[] getCount;
	int waitTime = 3;
	string platform_object_tag = "platform";
	string collide_object_tag = "Player";
	float platform_lifetime = 10.0f;
	float platform_death_start = 10.0f;
	
	void Update(){
		InvokeRepeating ("destroyPlatform", platform_death_start, platform_lifetime);
	}

	void destroyPlatform(){
		getCount = GameObject.FindGameObjectsWithTag(platform_object_tag);
		Destroy (getCount[0]);
	}
	
	void OnCollisionEnter(Collision collision){
		if (collision.collider.CompareTag(collide_object_tag)) {
			possiblePlatforms();
			possiblePlatforms();
		}
		MyCoroutine ();
	}

	IEnumerator MyCoroutine(){
		print(Time.time);
		yield return new WaitForSeconds(waitTime);
		print(Time.time);
	}

	void possiblePlatforms(){
		int casePlatforms = Random.Range (0, 12);
		switch (casePlatforms) 
		{
			case 0:
				Instantiate (platform, new Vector3(this.transform.position.x, 
				                                   this.transform.position.y, 
				                                   this.transform.position.z - 1.0f), 
				             Quaternion.identity);
				Debug.Log("block spawn BACK");
				break;
			case 1:
				Instantiate (platform, new Vector3(this.transform.position.x, 
				                                   this.transform.position.y, 
				                                   this.transform.position.z + 1.0f), 
				             Quaternion.identity);
				Debug.Log ("block spawn FORWARD");
				break;
			case 2:
				Instantiate (platform, new Vector3(this.transform.position.x - 1.0f,	 
				                                   this.transform.position.y, 
				                                   this.transform.position.z), 
				             Quaternion.identity);
				Debug.Log("block spawn LEFT");
				break;
			case 3:
				Instantiate (platform, new Vector3(this.transform.position.x + 1.0f, 
				                                   this.transform.position.y, 
				                                   this.transform.position.z), 
				             Quaternion.identity);
				Debug.Log ("block spawn RIGHT");
				break;
			case 4:
				Instantiate (platform, new Vector3(this.transform.position.x + 1.0f, 
			                                   this.transform.position.y + 0.25f, 
			                                   this.transform.position.z), 
			             Quaternion.identity);
				Debug.Log ("block spawn UP RIGHT");
			break;
			case 5:
				Instantiate (platform, new Vector3(this.transform.position.x - 1.0f, 
			                                   this.transform.position.y + 0.25f, 
			                                   this.transform.position.z), 
			             Quaternion.identity);
				Debug.Log ("block spawn UP LEFT");
				break;
			case 6:
				Instantiate (platform, new Vector3(this.transform.position.x, 
			                                   this.transform.position.y + 0.25f, 
			                                   this.transform.position.z + 1.0f), 
			             Quaternion.identity);
			Debug.Log ("block spawn UP FORWARD");
			break;
			case 7:
				Instantiate (platform, new Vector3(this.transform.position.x, 
			                                   this.transform.position.y + 0.25f, 
			                                   this.transform.position.z - 1.0f), 
			             Quaternion.identity);
				Debug.Log ("block spawn UP BACK");
			break;
			case 8:
				Instantiate (platform, new Vector3(this.transform.position.x + 1.0f, 
				                                   this.transform.position.y - 0.25f, 
				                                   this.transform.position.z), 
				             Quaternion.identity);
				Debug.Log ("block spawn DOWN RIGHT");
			break;
			case 9:
				Instantiate (platform, new Vector3(this.transform.position.x - 1.0f, 
				                                   this.transform.position.y - 0.25f, 
				                                   this.transform.position.z), 
				             Quaternion.identity);
				Debug.Log ("block spawn DOWN LEFT");
			break;
			case 10:
				Instantiate (platform, new Vector3(this.transform.position.x, 
				                                   this.transform.position.y - 0.25f, 
				                                   this.transform.position.z + 1.0f), 
				             Quaternion.identity);
				Debug.Log ("block spawn DOWN FORWARD");
			break;
			case 11:
				Instantiate (platform, new Vector3(this.transform.position.x, 
				                                   this.transform.position.y - 0.25f, 
				                                   this.transform.position.z - 1.0f), 
				             Quaternion.identity);
				Debug.Log ("block spawn DOWN BACK");
			break;
			default:
				Debug.Log ("possiblePlatforms case statement broke");
				break;
		}
	}
}
