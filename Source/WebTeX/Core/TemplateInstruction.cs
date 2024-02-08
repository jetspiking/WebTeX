using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTeX.Core
{
    public class TemplateInstruction
    {
        public string Template;
        public TemplateValue[]? Properties;
        public TemplateInstruction[]? Children;

        public TemplateInstruction(string template, TemplateValue[]? properties, TemplateInstruction[]? children)
        {
            Template = template;
            Properties = properties;
            Children = children;
        }
    }

    public class TemplateValue
    {
        public string Id;
        public string Assign;

        public TemplateValue(string id, string assign)
        {
            Id = id;
            Assign = assign;
        }
    }
}
