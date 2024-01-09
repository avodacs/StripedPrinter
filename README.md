# Striped Printer

Library that allows for printing ZPL labels directly to a Zebra Printer without a driver.

## Usage

Prints a label using Fluid.


```cs
using ZPLPrinter;

var template = "^XA^FO50,50^ADN,36,20^FD{{Name}}^FS^XZ";
var model = new { Name = "Hello World" };
var label = new ZPLLabel(template, model);

var printer = new ZPLPrinter("127.0.0.1");
printer.Print(label);
```

Prints a simple label without using Fluid.

```cs
using ZPLPrinter;

var template = "^XA^FO50,50^ADN,36,20^FDHello World^FS^XZ";
var label = new ZPLLabel(template);

var printer = new ZPLPrinter("127.0.0.1");
printer.Print(label);
```