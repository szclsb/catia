using System.Linq;
using System.Runtime.InteropServices;
using INFITF;

namespace shared
{
    public class Bootstrap
    {
        private const string ProgramId = "CATIA.Application";

        public static Application Init()
        {
            try
            {
                return (Application) Marshal.GetActiveObject(ProgramId);
            }
            catch
            {
                throw new COMException("CATIA is not running.");
            }
        }

        public static bool IsDocValid(Document document, params DocType[] docTypes)
        {
            return docTypes.Any(docType => docType.IsValid(document));
        }
    }
}