using System;
using Xamarin.Forms;

namespace MyShop
{
	public class FoodListViewModel : ViewModelBase
	{
		public FoodListViewModel (Page page) : base(page)
		{
            Title = "Food List";
		}
	}
}