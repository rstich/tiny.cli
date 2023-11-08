namespace Tiny.Cli.Misc;

public abstract class Parameter
{
    public static readonly string HelpText = """
                                             Usage: tiny [option] [argument]
                                             
                                                     Options:
                                                     -h, --help             Show this help information
                                                     -c, --current          Optimize all images in the current directory
                                                     -s, --subdir           Optimize all images in the current (or provided) directory and subdirectories
                                                     -f, --file <filename>  Optimize the specific file
                                                     -d, --dir <directory>  Optimize all images in the specific directory
                                                     -o, --out <directory>  Output directory for optimized images
                                                     -r, --resize <size>    resize to specific size (only one number)
                                                     -u, --update           check if new version is available (will be done automatically once a week)
                                             """;
    
    public abstract record Help
    {
        public static string Simple => "-h";
        public static string Complex => "--help";
    }
    
    public abstract record SingleFile
    {
        public static string Simple => "-f";
        public static string Complex => "--file";
    }
    
    public abstract record CurrentDirectory
    {
        public static string Simple => "-c";
        public static string Complex => "--current";
    }
    
    public abstract record Directory
    {
        public static string Simple => "-d";
        public static string Complex => "--dir";
    }

    public abstract record SubDirectory
    {
        public static string Simple => "-s";
        public static string Complex => "--subdir";
    }

    public abstract record OutPutDir
    {
        public static string Simple => "-o";
        public static string Complex => "--out";
    }
    
    public abstract record Resize
    {
        public static string Simple => "-r";
        public static string Complex => "--resize";
    }

    public abstract record Update
    {
        public static string Simple => "-u";
        public static string Complex => "--update";
    }
}