using System.Collections.Generic;
using Contrib.Taxonomies.Models;
using Contrib.Taxonomies.Services;
using Orchard.ContentManagement;
using Orchard.Environment;
using Orchard.Environment.Extensions.Models;

namespace Simian.Properties.Handlers
{
    public class PropertyFeatureEventHandler : IFeatureEventHandler
    {

        private readonly ITaxonomyService _taxonomyService;
        private readonly IContentManager _contentManager;

        public PropertyFeatureEventHandler(ITaxonomyService taxonomyService, IContentManager contentManager)
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
            CreateTaxonomy("PropertyType", new List<string> {
                "Single-Family Home",
                "Apartment",
                "Duplex",
                "Triplex",
                "Quadraplex",
                "Townhouse",
                "Detached House",
                "Cottage",
                "Cabin",
                "Multi-Family Home",
                "Villa",
                "Zero-Lot-Line Home",
                "Patio Home",
                "Courtyard Home",
                "Terraced House",
                "Condominium",
                "Timeshare/Interval Ownership",
                "Housing Cooperative",
                "Land Lease",
                "Carriage Home/Coach Home",
                "Mobile Home",
                "Houseboat",
                "Boxcar",
                "Tent"
            });
            CreateTaxonomy("Ammenities", new List<string> {
                "Air Conditioning",
                "Washer and Dryer",
                "Laundromat on Property",
                "Dishwasher",
                "On Site Security",
                "Pets Allowed",
                "Smoking Allowed",
                "Fireplace",
                "Walk In Closet",
                "Hot Tub / Spa",
                "Cable Tv",
                "High Speed Internet",
                "Community Grill",
                "Covered Parking",
                "Gated /Controlled Entrance",
                "Bus/Public Transportation"
            });
            CreateTaxonomy("RentOrSale", new List<string> {"Rent","Sale"});
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