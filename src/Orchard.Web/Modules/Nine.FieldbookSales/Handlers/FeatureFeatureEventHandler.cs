using System.Collections.Generic;
using Contrib.Taxonomies.Models;
using Contrib.Taxonomies.Services;
using Orchard.ContentManagement;
using Orchard.Environment;
using Orchard.Environment.Extensions.Models;

namespace Nine.FieldbookSales.Handlers
{
    public class FeatureFeatureEventHandler : IFeatureEventHandler
    {

        private readonly ITaxonomyService _taxonomyService;
        private readonly IContentManager _contentManager;

        public FeatureFeatureEventHandler(ITaxonomyService taxonomyService, IContentManager contentManager)
        {
            _taxonomyService = taxonomyService;
            _contentManager = contentManager;
        }

        public void Installing(Feature feature)
        {

        }

        public void Installed(Feature feature)
        {

        }

        public void Enabling(Feature feature)
        {

        }

        public void Enabled(Feature feature)
        {
            CreateTaxonomy("FeatureCategory", new List<string> {
                "Operations",
                "Accounting",
                "Accessibility",
                "Sales"
            });
        }

        private void CreateTaxonomy(string nameOfTaxonomy, List<string> terms)
        {
            if (_taxonomyService.GetTaxonomyByName(nameOfTaxonomy) == null)
            {

                var taxonomy = _contentManager.New<TaxonomyPart>("Taxonomy");
                taxonomy.Name = nameOfTaxonomy;
                _contentManager.Create(taxonomy, VersionOptions.Published);
                terms.ForEach(t => CreateTerm(taxonomy, t));
            }
        }

        private void CreateTerm(TaxonomyPart taxonomyPart, string name)
        {
            var term = _taxonomyService.NewTerm(taxonomyPart);
            term.Name = name;
            _contentManager.Create(term, VersionOptions.Published);
        }

        public void Disabling(Feature feature)
        {

        }

        public void Disabled(Feature feature)
        {

        }

        public void Uninstalling(Feature feature)
        {

        }

        public void Uninstalled(Feature feature)
        {

        }
    }
}