using WebTeX.Core;

namespace WebTeX.Pages
{
    public class DemoPageJson : EldynTemplate
    {
        private String _title;
        private String _description;
        private String _url;
        private String _image;
        private String _webUrl;

        public DemoPageJson(String title, String description, String url, String image, String webUrl)
        {
            _title = title;
            _description = description;
            _url = url;
            _image = image;
            _webUrl = webUrl;
        }

        public override TemplateInstruction GetInstruction()
        {
            TemplateValue[] apodValues = { new TemplateValue("Title", _title), new TemplateValue("Explain", _description), new TemplateValue("Url", _url), new TemplateValue("Apod", _image) };
            TemplateInstruction[] demoTemplates = { new("Demo", apodValues, null) };
            TemplateInstruction templateInstruction = new("Index", new TemplateValue[] { new TemplateValue("WebUrl", _webUrl) }, demoTemplates);
            return templateInstruction;
        }
    }
}
