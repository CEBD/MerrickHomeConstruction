using Orchard.UI.Resources;

namespace Simian.Properties {
    public class ResourceManifest :IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {

            var manifest = builder.Add();

            manifest.DefineStyle("Waffles").SetUrl("Waffles.css");

        }
    }
}