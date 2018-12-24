using UnityEngine;

[ExecuteInEditMode]
public class GlobalSpriteFogColor : MonoBehaviour
{
	public static GlobalSpriteFogColor Instance;

	public Color FogColor = Color.white;

	public void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(this);
	}
}
