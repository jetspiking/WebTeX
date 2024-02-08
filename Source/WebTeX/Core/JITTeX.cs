namespace WebTeX.Core
{
    public class JITTeX
    {
        public WebTeXArgs Configuration;
        public JITTeX(WebTeXArgs configuration)
        {
            Configuration = configuration;
        }

        public Boolean InvokeEldyn(String file)
        {
            String arguments = $"{Path.Combine(Configuration.RootDirectoryPath, Configuration.PdfOutputTemporaryDirectoryName,"eldyn.json")} {Path.Combine(Configuration.RootDirectoryPath, Configuration.EldynTemplateDirectoryName)} {Path.Combine(Configuration.RootDirectoryPath, Configuration.TeXServeDirectoryName,file+".tex")}";
            return CommandInvoker.InvokeProcess(Configuration.EldynExecutablePath, arguments);
        }

        public String CompileTeXFile(String file)
        {
            String arguments = $"-output-directory=\"{Path.Combine(Configuration.RootDirectoryPath, Configuration.PdfOutputTemporaryDirectoryName)}\" -interaction=nonstopmode \"{Path.Combine(Configuration.RootDirectoryPath, Configuration.TeXServeDirectoryName, file + ".tex")}\"";
            CommandInvoker.InvokeProcess(Configuration.PdfLaTeXExecutablePath, arguments, Path.Combine(Configuration.RootDirectoryPath, Configuration.TeXServeDirectoryName));
            return Path.Combine(Configuration.RootDirectoryPath, Configuration.PdfOutputTemporaryDirectoryName, file + ".pdf");
        }
    }
}
