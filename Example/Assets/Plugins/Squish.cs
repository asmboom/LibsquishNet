using System.Runtime.InteropServices;

namespace Squish {
	public class Squish {
		public const string DLL_NAME = "csquish";

		public enum Flags {
			//! Use DXT1 compression.
			kDxt1 = ( 1 << 0 ), 
			
			//! Use DXT3 compression.
			kDxt3 = ( 1 << 1 ), 
			
			//! Use DXT5 compression.
			kDxt5 = ( 1 << 2 ), 
			
			//! Use a very slow but very high quality colour compressor.
			kColourIterativeClusterFit = ( 1 << 8 ),	
			
			//! Use a slow but high quality colour compressor (the default).
			kColourClusterFit = ( 1 << 3 ),	
			
			//! Use a fast but low quality colour compressor.
			kColourRangeFit	= ( 1 << 4 ),
			
			//! Use a perceptual metric for colour error (the default).
			kColourMetricPerceptual = ( 1 << 5 ),
			
			//! Use a uniform metric for colour error.
			kColourMetricUniform = ( 1 << 6 ),
			
			//! Weight the colour by alpha during cluster fit (disabled by default).
			kWeightColourByAlpha 
		};

		[DllImport(DLL_NAME)]
		public static extern void Compress(byte[] rgba, byte[] block, System.Int32 flags);

		[DllImport(DLL_NAME)]
		public static extern void CompressMasked(byte[] rgba, System.Int32 mask, byte[] block, System.Int32 flags );

		[DllImport(DLL_NAME)]
		public static extern void Decompress(byte[] rgba, byte[] block, System.Int32 flags );

		[DllImport(DLL_NAME)]
		public static extern int GetStorageRequirements( System.Int32 width, System.Int32 height, System.Int32 flags );

		[DllImport(DLL_NAME)]
		public static extern void CompressImage(byte[] rgba, System.Int32 width, System.Int32 height, byte[] blocks, System.Int32 flags );

		[DllImport(DLL_NAME)]
		public static extern void DecompressImage(byte[] rgba, System.Int32 width, System.Int32 height, byte[] blocks, System.Int32 flags );
	}
}
