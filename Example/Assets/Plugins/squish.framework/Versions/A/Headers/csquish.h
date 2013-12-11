/* -----------------------------------------------------------------------------

	Copyright (c) 2006 Simon Brown                          si@sjbrown.co.uk

	Permission is hereby granted, free of charge, to any person obtaining
	a copy of this software and associated documentation files (the 
	"Software"), to	deal in the Software without restriction, including
	without limitation the rights to use, copy, modify, merge, publish,
	distribute, sublicense, and/or sell copies of the Software, and to 
	permit persons to whom the Software is furnished to do so, subject to 
	the following conditions:

	The above copyright notice and this permission notice shall be included
	in all copies or substantial portions of the Software.

	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
	OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
	MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
	IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY 
	CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 
	TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
	SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
	
   -------------------------------------------------------------------------- */
   
#ifndef CSQUISH_H
#define CSQUISH_H

extern "C" {
    void Compress( u8 const* rgba, void* block, int flags );
    void CompressMasked( u8 const* rgba, int mask, void* block, int flags );
    void Decompress( u8* rgba, void const* block, int flags );
    int GetStorageRequirements( int width, int height, int flags );
    void CompressImage( u8 const* rgba, int width, int height, void* blocks, int flags );
    void DecompressImage( u8* rgba, int width, int height, void const* blocks, int flags );
}

void Compress( u8 const* rgba, void* block, int flags ) {
    squish::Compress(rgba, block, flags);
}

void CompressMasked( u8 const* rgba, int mask, void* block, int flags ) {
    squish::CompressMasked(rgba, mask, block, flags);
}

void Decompress( u8* rgba, void const* block, int flags ) {
    squish::Decompress(rgbs, block, flags);
}

int GetStorageRequirements( int width, int height, int flags ) {
    squish::GetStorageRequirements(width, height, flags);
}

void CompressImage( u8 const* rgba, int width, int height, void* blocks, int flags ) {
    squish::CompressImage(rgba, width, height, block, flags);
}

void DecompressImage( u8* rgba, int width, int height, void const* blocks, int flags ) {
    squish::DecompressImage(rgba, width, height, blocks, flags);
}

#endif // ndef CSQUISH_H

