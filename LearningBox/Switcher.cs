using System.Windows.Controls;

namespace LearningBox
{
  	public static class Switcher
  	{
    	public static PageSwitcher pageSwitcher;

    	public static void Switch(UserControl newPage)
    	{
      		pageSwitcher.Navigate(newPage);
    	}

    	public static void Switch(UserControl newPage, object state)
    	{
      		pageSwitcher.Navigate(newPage, state);
    	}
  	}
}
