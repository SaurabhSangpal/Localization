using System;
using System.Collections.Generic;
using System.IO;
using ExcelDataReader;

namespace Wolves.Localization
{
    public class Localization
    {
        private Dictionary<string, string> activeLanguageData;

        // By default, the second column will be the active language.
        private readonly int activeLanguageIndex;

        public Localization(int languageId, Stream stream) {
            activeLanguageIndex = languageId;
            ReadExcelData(stream);
        }

        public string GetLocalizedText(string key) {
            if (activeLanguageData.TryGetValue(key, out var _value)) {
                return _value;
            }

            throw new ArgumentOutOfRangeException($"{key} not present in dictionary.");
        }

        private void ReadExcelData(Stream stream) {
            activeLanguageData = new Dictionary<string, string>();
            using var _reader = ExcelReaderFactory.CreateReader(stream);
            do {
                while (_reader.Read()) {
                    AddValueToDictionary(_reader);
                }
            } while (_reader.NextResult());
        }

        private void AddValueToDictionary(IExcelDataReader reader) {
            activeLanguageData[reader.GetString(0)] =
                reader.GetString(activeLanguageIndex);
        }
    }
}