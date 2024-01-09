using Fluid;

namespace StripedPrinter;

public class ZPLLabel
{
    private string _template { get; set; }
    private object? _model { get; set; }

    public ZPLLabel(string template)
    {
        _template = template;
    }

    public ZPLLabel(string template, object model)
    {
        _template = template;
        _model = model;
    }

    private string Parse()
    {
        if (_model == null) return _template;

        var parser = new FluidParser();
        if (!parser.TryParse(_template, out var template, out var error))
            throw new Exception("Template parsing failed");

        var context = new TemplateContext(_model);
        return template.Render(context);
    }

    public string Render() => Parse();
}