using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf;
using OutSystems.ExternalLibraries.SDK;
using System.Reflection.PortableExecutable;
using System.Text;

namespace iText7Wrapper
{
    [OSInterface(Description = "Leverages the iText Core library (itextpdf.com) for PDF related operations." +
        "Currently implements the extraction of text from a PDF file.", IconResourceName = "iText7Wrapper.icon.png", Name = "iText7CoreWrapper")]
    public interface IiText7Wrapper
    {
        public string GetText(byte[] pdfBytes);
    }

    public class iText7Wrapper : IiText7Wrapper
    {

        public string GetText(byte[] pdfBytes)
        {
            //Create a PDF document instance by loading a byte array 
            PdfDocument pdfDoc = new PdfDocument(new PdfReader(new MemoryStream(pdfBytes))); //pdfBytes is the input parameter
                                                                           //Create a text extraction strategy instance
            ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
            //Create a string builder to store the extracted text
            StringBuilder sb = new StringBuilder();
            //Loop through the pages of the PDF document
            for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
            {
                //Extract the text from the page
                string pageText = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i), strategy);
                //Append the text to the string builder
                sb.Append(pageText);
            }
            //Close the document
            pdfDoc.Close();
            //Get the extracted text as a string
            return sb.ToString();
        }
    }
}