using UnityEngine;
using System.Collections;

public class winPlaneController : MonoBehaviour {

	public GameObject player;
	public GameObject platform;

	string player_tag = "Player";
	float max_dist = 10.0f;
	float min_dist = 7.5f;
	int[] posOrneg = {-1, 1};
	private GameObject[] platforms;
	string platform_object_tag = "platform";
	int current_level;


	void Start(){
		this.transform.position = new Vector3 (0, 0.25f, 7.5f);
		current_level = 1;
	}

	void OnCollisionEnter(Collision collision){

		int current_score = GameObject.Find("mochii_model").GetComponent<mochiiPlayer>().current_score;
		int initial_moves = GameObject.Find("mochii_model").GetComponent<mochiiPlayer>().initial_moves;

		if (collision.collider.CompareTag (player_tag)) {
			Debug.Log ("YOU WINNNN :D");

			// Update HUD with win condition
			// i.e. add player moves left to player score
			// increment player moves left
			GameObject.Find("mochii_model").GetComponent<mochiiPlayer>().current_score += initial_moves;

			GameObject.Find ("mochii_model").GetComponent<mochiiPlayer>().hudTextMesh.text = "Moves Left: " 
				+ initial_moves.ToString() 
				+ "\n"
				+ "Current Score: " 
				+ GameObject.Find("mochii_model").GetComponent<mochiiPlayer>().current_score;

			// Increment player level and give player more moves based on level
			current_level += 1;
			GameObject.Find("mochii_model").GetComponent<mochiiPlayer>().initial_moves += (current_level * 5);

			// return player to start plane
			player.transform.position = new Vector3(4.514f, 0.02f, 4.48f);
			player.transform.rotation = Quaternion.identity;

			// destroy current platforms
			platforms = GameObject.FindGameObjectsWithTag(platform_object_tag);
			for (int i = 0; i < platforms.Length; i++){
				Destroy (platforms[i]);
			}

			// re-instantiate platform
			Instantiate(platform, new Vector3(3.53f, 0.14f, 4.48f), Quaternion.identity);

			// calculate distance between start_plane and win_plane
			this.transform.position = new Vector3(Random.Range (min_dist, max_dist) * posOrneg[Random.Range(0,2)], 
			                                      0.25f, 
			                                      Random.Range(min_dist, max_dist) * posOrneg[Random.Range(0,2)]);
			max_dist += 2.5f;
			min_dist += 2.5f;
			// move win_plane
			// increment level/score
		}
	}
}
