using PdfSharp.Fonts;
using System.IO;

public class CustomFontResolver : IFontResolver
{
    private readonly byte[] _regularFont;
    private readonly byte[] _boldFont;
    private readonly byte[] _italicFont;
    private readonly byte[] _boldItalicFont;

    public CustomFontResolver()
    {
        _regularFont = File.ReadAllBytes("wwwroot/fonts/LiberationSans-Regular.ttf");
        _boldFont = File.ReadAllBytes("wwwroot/fonts/LiberationSans-Bold.ttf");
        _italicFont = File.ReadAllBytes("wwwroot/fonts/LiberationSans-Italic.ttf");
        _boldItalicFont = File.ReadAllBytes("wwwroot/fonts/LiberationSans-BoldItalic.ttf");
    }

    public byte[] GetFont(string faceName)
    {
        return faceName switch
        {
            "LiberationSans-Bold" => _boldFont,
            "LiberationSans-Italic" => _italicFont,
            "LiberationSans-BoldItalic" => _boldItalicFont,
            _ => _regularFont,
        };
    }

    public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
    {
        
        if (isBold && isItalic)
            return new FontResolverInfo("LiberationSans-BoldItalic");
        if (isBold)
            return new FontResolverInfo("LiberationSans-Bold");
        if (isItalic)
            return new FontResolverInfo("LiberationSans-Italic");

        return new FontResolverInfo("LiberationSans-Regular");
    }

}
