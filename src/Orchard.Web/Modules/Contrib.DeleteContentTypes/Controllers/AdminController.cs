using System.Linq;
using System.Web.Mvc;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Settings.Metadata.Records;
using Orchard.Data;
using Orchard.Localization;
using Orchard.Mvc.AntiForgery;
using Orchard.Security;
using Orchard.UI.Notify;

namespace Contrib.DeleteContentTypes.Controllers {
    public class AdminController : Controller {
        private readonly IRepository<ContentTypeDefinitionRecord> _contentTypeDefinitionRecordRepository;
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public AdminController(
            IRepository<ContentTypeDefinitionRecord> contentTypeDefinitionRecordRepository, 
            IContentDefinitionManager contentDefinitionManager, 
            IOrchardServices services) {
            _contentTypeDefinitionRecordRepository = contentTypeDefinitionRecordRepository;
            _contentDefinitionManager = contentDefinitionManager;
            Services = services;
            T = NullLocalizer.Instance;
        }

        public IOrchardServices Services { get; private set; }
        public Localizer T { get; set; }

        [HttpPost]
        public ActionResult DeleteContentType(string contentType) {
            if (!Services.Authorizer.Authorize(Orchard.ContentTypes.Permissions.EditContentTypes, T("Not allowed to delete content types.")))
                return new HttpUnauthorizedResult();

            var definition = _contentTypeDefinitionRecordRepository.Fetch(x => x.Name == contentType).SingleOrDefault();

            // deletes the content type record associated
            if(definition != null) {
                _contentTypeDefinitionRecordRepository.Delete(definition);
            }

            // invalidates the cache
            _contentDefinitionManager.AlterTypeDefinition("User", alteration => { });

            // delete all content items (but not old versions)
            var contentItems = Services.ContentManager.Query(contentType).List();
            foreach (var contentItem in contentItems) {
                Services.ContentManager.Remove(contentItem);
            }

            Services.Notifier.Information(T("Deleted {0} content type and removed {1} content items.", contentType, contentItems.Count()));

            return RedirectToAction("Index", "Admin", new { area = "Orchard.ContentTypes"});
        }
    }
}