using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperLevelSpawnner : MonoBehaviour
{
	public GameObject[] levels;
	Vector3 instantiatePos;
	public float aboveVal;
	public float belowVal;
	JumperLevelSpawnner ls;
	int rand;

	void Start()
	{
		Debug.Log(Screen.orientation.ToString());
		rand = Random.Range(0, levels.Length);
		ls = levels[rand].GetComponent<JumperLevelSpawnner>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("destroyer"))
		{
			instantiatePos = transform.position;
			instantiatePos.y += aboveVal + ls.belowVal;
			Instantiate(levels[rand], instantiatePos, Quaternion.identity);
		}
	}

}