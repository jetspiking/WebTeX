using WebTeX.Core;

namespace WebTeX.Pages
{
    public class DemoErrorPageJson : EldynTemplate
    {
        private String _webUrl;
        public DemoErrorPageJson(String webUrl)
        {
            _webUrl = webUrl;
        }

        public override TemplateInstruction GetInstruction()
        {
            TemplateInstruction[] demoTemplates = { new("DemoError", null, null) };
            TemplateInstruction templateInstruction = new("Index", new TemplateValue[] { new TemplateValue("WebUrl", _webUrl) }, demoTemplates);
            return templateInstruction;
        }
    }
}
