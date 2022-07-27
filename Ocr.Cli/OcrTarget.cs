using IronOcr;

namespace Ocr.Cli;
public struct OcrTarget
{
    public string Name { get; set; }
    public string Path { get; set; }
    public CropRectangle Region { get; set; }
}