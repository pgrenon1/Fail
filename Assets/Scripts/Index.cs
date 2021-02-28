using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Index : ScriptableObject
{
	private static Index _instance;

	public static Index Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Resources.Load<Index>("Index");

				if (_instance == null)
				{
					Debug.LogWarning("Failed to load Index asset. Make sure it is placed directly at: Resources/Index.asset");
				}
			}

			return _instance;
		}
	}

	public string saveFileName = "save.json";
	public IconDictionary iconDictionary;
	public SceneIndex sceneIndex;

	public IconDictionary IconDictionary { get { return iconDictionary; } }
	public SceneIndex SceneIndex { get { return sceneIndex; } }
	public string SaveFileName { get { return saveFileName; } }

}
