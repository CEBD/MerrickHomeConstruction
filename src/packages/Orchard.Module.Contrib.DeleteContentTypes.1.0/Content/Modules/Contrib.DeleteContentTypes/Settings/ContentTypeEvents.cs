using System.Collections.Generic;
using Orchard.ContentManagement;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.ContentManagement.MetaData.Models;
using Orchard.ContentManagement.ViewModels;

namespace Contrib.DeleteContentTypes.Settings {
    public class ContentTypeEvents : ContentDefinitionEditorEventsBase {

        public override IEnumerable<TemplateViewModel> TypeEditor(ContentTypeDefinition definition) {
            var model = new ContentTypeSettings {ContentType = definition.Name};
            yield return DefinitionTemplate(model);
        }

        public override IEnumerable<TemplateViewModel> TypeEditorUpdate(ContentTypeDefinitionBuilder builder, IUpdateModel updateModel) {
            var model = new ContentTypeSettings();
            updateModel.TryUpdateModel(model, "ContentTypeSettings", null, null);
            yield return DefinitionTemplate(model);
        }

    }
}