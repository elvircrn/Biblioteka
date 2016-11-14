using System.Collections.Generic;

namespace Biblioteka.Model
{
    public interface INaucniRad
    {
        string GeneralneInformacije();

        List<string> AutoriRada();

        string OblastNauke();

        string OblikReferenciranja();
    }
}