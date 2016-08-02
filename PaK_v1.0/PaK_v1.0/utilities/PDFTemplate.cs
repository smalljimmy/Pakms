using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace PaK_v1._0.utilities
{
    class PDFTemplate
    {
        public static string appRootDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;

        public static void ReplacePdfForm(List<KeyValuePair<string, string>> keys, string tpl, string target)
        {

        //    string appRootDir = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.FullName;
            string fileNameExisting = appRootDir + "\\tpl\\" + tpl;
            string strnow = DateTime.Now.ToFileTimeUtc().ToString();
            string fileNameNew = appRootDir + "\\pdf\\" + target;

            using (var existingFileStream = new FileStream(fileNameExisting, FileMode.Open))
            using (var newFileStream = new FileStream(fileNameNew, FileMode.Create))
            {
                // Open existing PDF
                var pdfReader = new PdfReader(existingFileStream);

                // PdfStamper, which will create
                var stamper = new PdfStamper(pdfReader, newFileStream);

                var form = stamper.AcroFields;
                form.GenerateAppearances = true;

                var fieldKeys = form.Fields.Keys;
                foreach (string fieldKey in fieldKeys)
                {
                    foreach (var item in keys)
                    {
                        if (fieldKey == item.Key)
                        {
                            form.SetField(fieldKey, item.Value);
                            break;
                        }
                    }
                }

                //form.SetField("Today", "REPLACED!");

                // "Flatten" the form so it wont be editable/usable anymore
                stamper.FormFlattening = true;

                // You can also specify fields to be flattened, which
                // leaves the rest of the form still be editable/usable
                //stamper.PartialFormFlattening("Today");

                stamper.Close();
                pdfReader.Close();
            }
        }

        public static void MergeFiles(string destinationFile, List<string> sourceFiles)
        {
            int f = 0;
            // we create a reader for a certain document
            PdfReader reader = new PdfReader(sourceFiles[f]);
            // we retrieve the total number of pages
            int n = reader.NumberOfPages;
            // step 1: creation of a document-object
            Document document = new Document(reader.GetPageSizeWithRotation(1));
            // step 2: we create a writer that listens to the document
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(destinationFile, FileMode.Create));
            // step 3: we open the document
            document.Open();
            PdfContentByte cb = writer.DirectContent;
            PdfImportedPage page;
            int rotation;
            // step 4: we add content
            while (f < sourceFiles.Count)
            {
                int i = 0;
                while (i < n)
                {
                    i++;
                    document.SetPageSize(reader.GetPageSizeWithRotation(i));
                    document.NewPage();
                    page = writer.GetImportedPage(reader, i);
                    rotation = reader.GetPageRotation(i);
                    if (rotation == 90 || rotation == 270)
                    {
                        cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
                    }
                    else
                    {
                        cb.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
                    }
                }
                f++;
                if (f < sourceFiles.Count)
                {
                    reader = new PdfReader(sourceFiles[f]);
                    // we retrieve the total number of pages
                    n = reader.NumberOfPages;
                }
            }
            // step 5: we close the document
            document.Close();
        }
    }
}
