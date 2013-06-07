using Orchard.UI.Resources;

namespace Simian.Properties {
    public class ResourceManifest :IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {

            var manifest = builder.Add();
            manifest.DefineScript("jQuery").SetUrl("jQuery-1.8.2.js");
            manifest.DefineStyle("GalleriaImageGallery").SetUrl("GalleriaImageGallery.css");
            manifest.DefineScript("GalleriaImageGallery").SetUrl("GalleriaImageGallery.js");
        }
    }
}