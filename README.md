# Localization
Localize Unity projects using Excel file format

By default it is assumed that the first column in your excel/Google sheets
worksheet will be the key, thereafter every new column will be a new language.
You must select which column to use for localization when creating the object.
The first column is 0 (this is where the keys are present). So, the first
language will be at column 1.

You have to also pass a Stream when creating the Localization object.

## Example
    using var _stream = File.Open(AssetDatabase.GetAssetPath(localizationText),
                                  FileMode.Open, FileAccess.Read);
    Localization = new Localization.Localization((int) language, _stream);

### A more detailed documentation will be written soon.