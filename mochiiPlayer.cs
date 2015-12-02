using UnityEngine;
using System.Collections;

public class mochiiPlayer : MonoBehaviour {

	public GameObject player;
	public GameObject platform;
	private GameObject[] platforms;
	public TextMesh hudTextMesh;
	string platform_object_tag = "platform";
	float point_of_loss = -3.0f;
	public int initial_moves;
	public int current_score;

	// Use this for initialization
	void Start () {
		initial_moves = 100;
		current_score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		float translation = 0.0f;
		float rotation = 0.0f;
		float vert = 0.0f;

		// Up & Down
		if (Input.GetButtonUp ("Vertical") & Input.GetAxis ("Vertical") > 0) {
			translation = 1.0f;
			vert = 0.5f;
			initial_moves -= 1;
			hudTextMesh.text = "Moves Left: " + initial_moves.ToString() + "\n"
				+ "Current Score: " + current_score;
		} 

		// Right & Left
		if (Input.GetButtonUp ("Horizontal") & Input.GetAxis ("Horizontal") > 0) {
			rotation = 90.0f;
		} else if (Input.GetButtonUp ("Horizontal") & Input.GetAxis ("Horizontal") < 0) {
			rotation = -90.0f;
		}

		// Move translation along the object's z-axis
		transform.Translate (0, Mathf.Abs (vert), translation);
		// Rotate around our y-axis
		transform.Rotate (0, rotation, 0);

		if (this.transform.position.y < point_of_loss) {
			Debug.Log ("YOU LOSE");
			current_score = 0;
			initial_moves = 100;
			hudTextMesh.text = "Moves Left: " + initial_moves.ToString() + "\n"
				+ "Current Score: " + current_score;

			player.transform.position = new Vector3(4.514f, 0.02f, 4.48f);
			player.transform.rotation = Quaternion.identity;
			
			// destroy current platforms
			platforms = GameObject.FindGameObjectsWithTag(platform_object_tag);
			for (int i = 0; i < platforms.Length; i++){
				Destroy (platforms[i]);
			}
			
			// re-instantiate new platform
			Instantiate(platform, new Vector3(3.53f, 0.14f, 4.48f), Quaternion.identity);

		}
	}
}
