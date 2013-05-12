﻿using System.Collections.Generic;
using System.Linq;
using Nwazet.Commerce.Models;
using Nwazet.Commerce.ViewModels;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Data;
using Orchard.Environment.Extensions;

namespace Nwazet.Commerce.Services {
    public interface IBundleService : IDependency {
        void UpdateBundleProducts(ContentItem item, IEnumerable<ProductEntry> products);
        IEnumerable<IContent> GetProducts();
        IEnumerable<ProductPartQuantity> GetProductQuantitiesFor(BundlePart bundle);
        BundleViewModel BuildEditorViewModel(BundlePart part);
        void AddProduct(int quantity, int product, BundlePartRecord record);
    }

    [OrchardFeature("Nwazet.Bundles")]
    public class BundleService : IBundleService {
        private readonly IContentManager _contentManager;
        private readonly IRepository<BundleProductsRecord> _bundleProductsRepository;

        public BundleService(
            IContentManager contentManager,
            IRepository<BundleProductsRecord> bundleProductsRepository) {

            _contentManager = contentManager;
            _bundleProductsRepository = bundleProductsRepository;
        }

        public void UpdateBundleProducts(ContentItem item, IEnumerable<ProductEntry> products) {
            var record = item.As<BundlePart>().Record;
            var oldProducts = _bundleProductsRepository.Fetch(
                r => r.BundlePartRecord == record);
            var lookupNew = products
                .Where(e => e.Quantity > 0)
                .ToDictionary(r => r.ProductId, r => r.Quantity);
            // Delete the products that are no longer there
            // and updtes the ones that should stay
            foreach (var bundleProductRecord in oldProducts) {
                var key = bundleProductRecord.ContentItemRecord.Id;
                if (lookupNew.ContainsKey(key)) {
                    bundleProductRecord.Quantity = lookupNew[key];
                    _bundleProductsRepository.Update(bundleProductRecord);
                    lookupNew.Remove(key);
                }
                else {
                    _bundleProductsRepository.Delete(bundleProductRecord);
                }
            }
            // Add the new products
            foreach (var productQuantity in lookupNew
                .Where(kvp => kvp.Value > 0)
                .Select(kvp => new ProductQuantity {ProductId = kvp.Key, Quantity = kvp.Value})) {

                AddProduct(productQuantity.Quantity, productQuantity.ProductId, record);
            }
        }

        public void AddProduct(int quantity, int product, BundlePartRecord record) {
            _bundleProductsRepository.Create(
                new BundleProductsRecord {
                    BundlePartRecord = record,
                    ContentItemRecord = _contentManager.Get(product).Record,
                    Quantity = quantity
                });
        }

        public IEnumerable<IContent> GetProducts() {
            return _contentManager
                .List<ProductPart>()
                .Where(p => !p.Has<BundlePart>());
        }

        public IEnumerable<ProductPartQuantity> GetProductQuantitiesFor(BundlePart bundle) {
            var quantities = bundle.ProductQuantities.ToDictionary(q => q.ProductId, q => q.Quantity);
            var parts = _contentManager.GetMany<ProductPart>(quantities.Keys, VersionOptions.Published, QueryHints.Empty);
            return parts.Select(p => new ProductPartQuantity {
                Product = p,
                Quantity = quantities[p.ContentItem.Id]
            }).ToList();
        } 

        public BundleViewModel BuildEditorViewModel(BundlePart part) {
            var bundleProductQuantities = part.ProductQuantities.ToDictionary(pq => pq.ProductId, pq => pq.Quantity);
            return new BundleViewModel {
                Products = GetProducts()
                    .Select(
                        p => new ProductEntry {
                            ProductId = p.ContentItem.Id,
                            Product = p,
                            Quantity = bundleProductQuantities.ContainsKey(p.Id) ? bundleProductQuantities[p.Id] : 0,
                            DisplayText = _contentManager.GetItemMetadata(p).DisplayText
                        }
                    )
                    .OrderBy(vm => vm.DisplayText)
                    .ToList()
            };
        }
    }
}
