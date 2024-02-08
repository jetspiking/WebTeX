namespace WebTeX.Core
{
    public abstract class TeXPage
    {
        protected JITTeX _jITTeX;
        protected String _template;
        public TeXPage(JITTeX jITTeX, String template)
        {
            _jITTeX = jITTeX;
            _template = template;
        }
        public async Task<Boolean> HandleRequest()
        {
            TemplateInstruction? demoRequest = await GetEldynJson();
            if (demoRequest != null)
            {
                JsonManager.SerializeToFile(demoRequest, Path.Combine(_jITTeX.Configuration.RootDirectoryPath, _jITTeX.Configuration.PdfOutputTemporaryDirectoryName, "eldyn.json"));
                _jITTeX.InvokeEldyn(_template);
                return true;
            }
            else return false;
        }

        protected abstract Task<TemplateInstruction?> GetEldynJson();
    }
}
