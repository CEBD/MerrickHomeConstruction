using System.Linq;
using FeaturedItemSlider.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using So.FeatureListSlider.Models;

namespace So.FeatureListSlider.Drivers
{
    public class FeatureListSliderWidgetPartDriver : ContentPartDriver<FeatureListSliderWidgetPart>
    {
        private readonly IContentManager _contentManager;

        public FeatureListSliderWidgetPartDriver(IContentManager contentManager)
        {
            _contentManager = contentManager;
        }

        protected override DriverResult Display(FeatureListSliderWidgetPart part, string displayType, dynamic shapeHelper)
        {
            int slideNumber = 0;

            var featuredItems = _contentManager.Query<FeaturedItemPart, FeaturedItemPartRecord>("FeaturedItem")
                .Where(fip => fip.GroupName == part.GroupName)
                .OrderBy(fi => fi.SlideOrder)
                .List()
                .Select(fi => new FeatureListSliderItemsViewModel
                {
                    Headline = fi.Headline,
                    SubHeadline = fi.SubHeadline,
                    LinkUrl = fi.LinkUrl,
                    IconPath = fi.Fields.Single(f => f.Name == "FeatureListSliderIcon").Storage.Get<string>("") != null ? fi.Fields.Single(f => f.Name == "FeatureListSliderIcon").Storage.Get<string>("") : "#",
                    ImagePath = fi.Fields.Single(f => f.Name == "Picture").Storage.Get<string>(""),
                    SlideNumber = ++slideNumber
                }).ToList();

            var group = _contentManager.Query<FeaturedItemGroupPart, FeaturedItemGroupPartRecord>("FeaturedItemGroup")
                .Where(fig => fig.Name == part.GroupName)
                .List()
                .SingleOrDefault();

            if (group != null)
            {
                group.BackgroundColor = group.BackgroundColor.TrimStart('#');
                group.ForegroundColor = group.ForegroundColor.TrimStart('#');
            }

            return ContentShape("Parts_FeatureListSliderItems", () => shapeHelper.Parts_FeatureListSliderItems(FeaturedItems: featuredItems, ContentPart: part, Group: group));
        }

        protected override DriverResult Editor(FeatureListSliderWidgetPart part, dynamic shapeHelper)
        {
            var groups = _contentManager.Query<FeaturedItemGroupPart, FeaturedItemGroupPartRecord>("FeaturedItemGroup")
                .List().Select(fig => fig.Name).ToList();

            var viewModel = new FeatureListSliderWidgetEditViewModel { GroupNames = groups, SelectedGroup = part.GroupName };
            return ContentShape("Parts_FeatureListSliderWidget_Edit", () => shapeHelper.EditorTemplate(TemplateName: "Parts.FeatureListSliderWidget.Edit", Model: viewModel));
        }

        protected override DriverResult Editor(FeatureListSliderWidgetPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, "", null, null);
            return Editor(part, shapeHelper);
        }
    }
}