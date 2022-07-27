using IronOcr;
using Ocr.Cli;

Installation.LicenseKey = "IRONOCR.JPSTILL85.9737-B9E3ABAF4E-E63S5ZBMEGJLL-SZJGCGORIRNN-SUFFMEUW4MWW-UGXPHAPUQTZ7-7MFMTO7RALNW-22FHWL-TFDUASHUGISHEA-DEPLOYMENT.TRIAL-IBLOQL.TRIAL.EXPIRES.26.AUG.2022";

var files = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "files");

var targets = new List<OcrTarget>
{
    new OcrTarget
    {
        Name = "dl-sample-al",
        Path = Path.Combine(files, "dl-sample-al.jpg"),
        Region = new CropRectangle(430, 238, 816, 382)
    },
    new OcrTarget
    {
        Name = "dl-sample-nc",
        Path = Path.Combine(files, "dl-sample-nc.jpg"),
        Region = new CropRectangle(345, 135, 718, 498)
    }
};

if (!Directory.Exists("results"))
    Directory.CreateDirectory("results");

IronTesseract Ocr = new()
{
    Language = OcrLanguage.EnglishBest,
    Configuration = new()
    {
        BlackListCharacters = @"é¥§£~“<>[]=+~`’©:;!.@#$%^&*()\|{}",
        ReadBarCodes = false
    }
};

foreach (var target in targets)
{
    using OcrInput input = new(target.Path, target.Region);
    
    var result = await Ocr.ReadAsync(input);

    if (result is not null)
        result.SaveAsTextFile(Path.Combine("results", $"{target.Name}.txt"));
}