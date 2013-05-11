﻿using Orchard.Localization;
using Orchard.Themes;

namespace Heikura.Orchard.Modules.SyntaxHighlighter {
    using global::Orchard.UI.Navigation;

    public class AdminMenu : INavigationProvider {
        public Localizer T { get; set; }

        public string MenuName {
            get {
                return "admin";
            }
        }

        public void GetNavigation(NavigationBuilder builder) {
            builder.Add(T("Themes"), menu => menu.Add(T("Syntax Highlighter"), "100",
                     item => item.Action("ChangeTheme", "Admin", 
                         new {
                             area = "Heikura.SyntaxHighlighter"
                         }).LocalNav().Permission(Permissions.ApplyTheme)));
        }
    }
}