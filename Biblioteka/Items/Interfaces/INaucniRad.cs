using System.Collections.Generic;

namespace Biblioteka.Model
{
    public interface INaucniRad
    {
        string generalneInformacije();

        List<string> autoriRada();

        string oblastNauke();

        string oblikReferenciranja();
    }
}