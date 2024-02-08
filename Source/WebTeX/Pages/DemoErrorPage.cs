using WebTeX.Core;

namespace WebTeX.Pages
{
    public class DemoErrorPage : TeXPage
    {
        public DemoErrorPage(JITTeX jITTeX, String template) : base(jITTeX, template)
        {
        }

        protected override Task<TemplateInstruction?> GetEldynJson()
        {
            TemplateInstruction instruction = new DemoErrorPageJson(_jITTeX.Configuration.WebsiteUrl).GetInstruction();
            if (instruction == null)
            {
                return Task.FromResult<TemplateInstruction?>(null);
            }
            else
            {
                return Task.FromResult<TemplateInstruction?>(instruction);
            }
        }
    }
}
