using WebTeX.Core;
using static System.Net.Mime.MediaTypeNames;

namespace WebTeX.Pages
{
    public class IndexPageJson : EldynTemplate
    {
        private String _webUrl;
        public IndexPageJson(String webUrl)
        {
            _webUrl = webUrl;
        }

        public override TemplateInstruction GetInstruction()
        {
            TemplateValue[] templateValues = { new TemplateValue("WebUrl", _webUrl) };
            TemplateInstruction[] demoTemplates = { new("Home", null, null) };
            TemplateInstruction templateInstruction = new("Index", templateValues, demoTemplates);
            return templateInstruction;
        }
    }
}
