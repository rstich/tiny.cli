CLI Tool to access tinypng.com API
================================

Usage: tiny [option] [argument]

Options:
----------
 * -h, --help             Show this help information
 * -c, --current          Optimize all images in the current directory 
 * -r, --recurse          Optimize all images in the current (or provided) directory and subdirectories
 * -f, --file [filename]  Optimize the specific file
 * -d, --dir [directory]  Optimize all images in the specific directory
 * -o, --out [directory]  Output directory for optimized images

Installation
--
dotnet tool install --global --add-source ./nupkg tiny.cli