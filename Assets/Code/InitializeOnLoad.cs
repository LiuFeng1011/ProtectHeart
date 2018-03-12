using UnityEngine;
using System.Collections;
using System.Runtime.Hosting;
using UnityEngine.SceneManagement;

public class InitializeOnLoad : MonoBehaviour {

	[RuntimeInitializeOnLoadMethod]
	static void Initialize()
	{
		if (SceneManager.GetActiveScene().name == "Gate" ||
            SceneManager.GetActiveScene().name == "TestScene"||
            SceneManager.GetActiveScene().name == "MapObj")
		{
			return;
		}
        SceneManager.LoadScene("Gate");
	}
}
