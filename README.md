CLI Tool to access tinypng.com API
================================
by Roger Stich, Roger.Stich@gmx.de

Usage: tiny [option] [argument]

Options:
----------
 * -h, --help             Show this help information
 * -c, --current          Optimize all images in the current directory 
 * -s, --subdir           Optimize all images in the current (or provided) directory and subdirectories
 * -f, --file [filename]  Optimize the specific file
 * -d, --dir [directory]  Optimize all images in the specific directory
 * -o, --out [directory]  Output directory for optimized images
 * -r, --resize [size]    resize to specific size (only one number)

Installation
--
you need an API Key from https://tinypng.com/developers
Set the API Key as Environment Variable TINY_KEY 
500 images per month are free, resizing count as one extra image
There is a check for the image size before resizing. 
If its smaller than the resize value, it will not be resized to safe compressions.

```
dotnet tool install --global --add-source ./nupkg tiny.cli
