using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[ExecuteInEditMode]
public class SpriteFog : MonoBehaviour
{
	public bool IgnoreGlobalFog;

	public Color BaseColor = Color.black;
	public Color FogColor = Color.white;
	
	[Range(0.0f, 10.0f)]
	public float Distance = 1.0f;

	private SpriteRenderer _spriteRenderer;
	public SpriteRenderer SpriteRenderer
	{
		get { return _spriteRenderer ?? (_spriteRenderer = GetComponent<SpriteRenderer>()); }
	}

	private MaterialPropertyBlock _propertyBlock;
	public MaterialPropertyBlock PropertyBlock
	{
		get { return _propertyBlock ?? (_propertyBlock = new MaterialPropertyBlock()); }
	}
	
	void Update ()
	{
		SpriteRenderer.GetPropertyBlock(PropertyBlock);

		var fogColor = GlobalSpriteFogColor.Instance == null || IgnoreGlobalFog
			? FogColor
			: GlobalSpriteFogColor.Instance.FogColor;
		
		PropertyBlock.SetColor("_Color", BaseColor);
		PropertyBlock.SetColor("_FogColor", fogColor);
		PropertyBlock.SetFloat("_Distance", Distance);
		
		SpriteRenderer.SetPropertyBlock(PropertyBlock);
	}
}
