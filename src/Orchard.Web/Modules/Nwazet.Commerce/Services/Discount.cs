﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Nwazet.Commerce.Models;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Environment.Extensions;
using Orchard.Mvc.Html;
using Orchard.Roles.Models;
using Orchard.Services;

namespace Nwazet.Commerce.Services {
    [OrchardFeature("Nwazet.Promotions")]
    public class Discount : IPromotion {
        private readonly IWorkContextAccessor _wca;
        private readonly IClock _clock;

        public Discount(IWorkContextAccessor wca, IClock clock) {
            _wca = wca;
            _clock = clock;
        }

        public DiscountPart DiscountPart { get; set; }
        public IContent ContentItem { get { return DiscountPart.ContentItem; } }
        public string Name { get { return DiscountPart == null ? "Discount" : DiscountPart.Name; } }

        public bool Applies(ShoppingCartQuantityProduct quantityProduct, IEnumerable<ShoppingCartQuantityProduct> cartProducts) {
            if (DiscountPart == null) return false;
            var now = _clock.UtcNow;
            if (DiscountPart.StartDate != null && DiscountPart.StartDate > now) return false;
            if (DiscountPart.EndDate != null && DiscountPart.EndDate < now) return false;
            if (DiscountPart.StartQuantity != null &&
                DiscountPart.StartQuantity > quantityProduct.Quantity)
                return false;
            if (DiscountPart.EndQuantity != null &&
                DiscountPart.EndQuantity < quantityProduct.Quantity)
                return false;
            if (!string.IsNullOrWhiteSpace(DiscountPart.Pattern)) {
                string path;
                if (DiscountPart.DisplayUrlResolver != null) {
                    path = DiscountPart.DisplayUrlResolver(quantityProduct.Product);
                }
                else {
                    var urlHelper = new UrlHelper(_wca.GetContext().HttpContext.Request.RequestContext);
                    path = urlHelper.ItemDisplayUrl(quantityProduct.Product);
                }
                if (!path.StartsWith(DiscountPart.Pattern, StringComparison.OrdinalIgnoreCase))
                    return false;
            }
            if (DiscountPart.Roles.Any()) {
                var user = _wca.GetContext().CurrentUser;
                if (user.Has<UserRolesPart>()) {
                    var roles = user.As<UserRolesPart>().Roles;
                    if (!roles.Any(r => DiscountPart.Roles.Contains(r))) return false;
                }
            }
            return true;
        }

        public ShoppingCartQuantityProduct Apply(ShoppingCartQuantityProduct quantityProduct, IEnumerable<ShoppingCartQuantityProduct> cartProducts) {
            if (DiscountPart == null) return quantityProduct;
            var comment = DiscountPart.Comment; // TODO: tokenize this
            var percent = DiscountPart.DiscountPercent;
            if (percent != null) {
                return new ShoppingCartQuantityProduct(quantityProduct.Quantity, quantityProduct.Product) {
                    Comment = comment,
                    Price = Math.Round(quantityProduct.Price * (1 - ((double)percent / 100)), 2)
                };
            }
            var discount = DiscountPart.Discount;
            if (discount != null) {
                return new ShoppingCartQuantityProduct(quantityProduct.Quantity, quantityProduct.Product) {
                    Comment = comment,
                    Price = Math.Round(Math.Max(0, quantityProduct.Price - (double)discount), 2)
                };
            }
            return quantityProduct;
        }
    }
}
