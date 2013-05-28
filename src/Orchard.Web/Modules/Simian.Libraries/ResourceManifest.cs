using Orchard.UI.Resources;

namespace Simian.Properties {
    public class ResourceManifest :IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {

            var manifest = builder.Add();

            manifest.DefineStyle("Waffles").SetUrl("Waffles.css");
            manifest.DefineStyle("Galleria.Simian").SetUrl("galleria.simian.css");

            manifest.DefineScript("Galleria").SetUrl("galleria.js");
            manifest.DefineScript("Galleria.Simian").SetUrl("galleria.simian.js");

            manifest.DefineScript("Knockout").SetUrl("knockout-2.0.js");
            manifest.DefineScript("JsRender").SetUrl("jsrender.js");


        }
    }
}