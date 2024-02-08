using Newtonsoft.Json;

namespace WebTeX.Core
{
    public class WebTeXArgs
    {
        public String RootDirectoryPath { get; set; }               // Directory path to root directory.
        public String TeXServeDirectoryName { get; set; }           // Directory name for serving TeX.
        public String PdfOutputTemporaryDirectoryName { get; set; } // Directory name for JIT files.
        public String EldynTemplateDirectoryName { get; set; }      // Directory name for ELDYN.
        public String PdfLaTeXExecutablePath { get; set; }          // Path to pdflatex compiler.
        public String EldynExecutablePath { get; set; }             // Path to ELDYN executable.
        public String WebsiteUrl { get; set; }                      // Server URL for serving the PDF.
        public String WebsitePort { get; set; }                     // Server port.
    }
}
