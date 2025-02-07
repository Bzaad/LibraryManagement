﻿using CoreBusiness;

namespace LibraryApp.ViewModels
{
    public class UserConsoleViewModel
    {
        public int SelectedCategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; }  = new List<Category>();

        public int SelectedBookId { get; set; }
    }
}
