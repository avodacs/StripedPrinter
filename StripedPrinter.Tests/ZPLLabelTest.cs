namespace StripedPrinter.Tests;

public class ZPLLabelTest
{
    [Fact]
    public void SimpleTemplateTest()
    {
        const string template = "^XA^FO50,50^ADN,36,20^FDHello World^FS^XZ";
        var label = new ZPLLabel(template);
        var zpl = label.Render();
        Assert.Equal(template, zpl);
    }

    [Fact]
    public void TemplateWithModelTest()
    {
        const string template = "^XA^FO50,50^ADN,36,20^FD{{Name}}^FS^XZ";
        var model = new { Name = "Hello World" };
        var label = new ZPLLabel(template, model);
        var zpl = label.Render();
        Assert.Equal("^XA^FO50,50^ADN,36,20^FDHello World^FS^XZ", zpl);
    }
}