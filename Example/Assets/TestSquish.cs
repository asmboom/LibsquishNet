using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class TestSquish : MonoBehaviour {
	public Material target;
	public Texture2D srcTex;

	private Texture2D _dstTex;

	// Use this for initialization
	void Start () {
		int width = srcTex.width;
		int height = srcTex.height;
		int blockSize = Squish.Squish.GetStorageRequirements(width, height, (int)Squish.Squish.Flags.kDxt1);

		byte[] block = new byte[blockSize];
		byte[] rgba = new byte[width * height * 4];
		var srcColors = srcTex.GetPixels32();
		for (var y = 0; y < height; y++) {
			for (var x = 0; x < width; x++) {
				var index = 4 * (x + y * width);
				var c = srcColors[x + y * width];
				rgba[index]		= c.r;
				rgba[index + 1] = c.g;
				rgba[index + 2] = c.b;
				rgba[index + 3] = c.a;
			}
		}

		var startTime = Time.realtimeSinceStartup;
		var ptrRgba = Marshal.AllocHGlobal(rgba.Length);
		var ptrBlock = Marshal.AllocHGlobal(block.Length);
		try {
			Marshal.Copy(rgba, 0, ptrRgba, rgba.Length);
			for (var i = 0; i < 10; i++) 
				Squish.Squish.CompressImage(ptrRgba, width, height, ptrBlock, (int)Squish.Squish.Flags.kDxt1);
			Marshal.Copy(ptrBlock, block, 0, block.Length);
		} finally {
			Marshal.FreeHGlobal(ptrRgba);
			Marshal.FreeHGlobal(ptrBlock);
		}
		var endTime = Time.realtimeSinceStartup;
		Debug.Log("Elapsed : " + (endTime - startTime));

		_dstTex = new Texture2D(width, height, TextureFormat.DXT1, false);
		_dstTex.LoadRawTextureData(block);
		//_dstTex.filterMode = FilterMode.Point;
		_dstTex.Apply(false);

		target.mainTexture = _dstTex;

		Debug.Log(string.Format("Texture format={0} size={1} original={2}", _dstTex.format, blockSize, rgba.Length));
	}

	void OnDestroy() {
		Destroy(_dstTex);
	}
}
