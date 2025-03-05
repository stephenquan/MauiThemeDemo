using System.Text.RegularExpressions;

namespace MauiThemeDemo;

/// <summary>
/// A helper class to set the theme of the application.
/// </summary>
public static partial class ThemeHelper
{
	[GeneratedRegex(@"^Active(\w+)$")]
	public static partial Regex ThemeRegex();

	/// <summary>
	/// Scan the ActiveXXX keys in the dictionary and set the values to the corresponding theme.
	/// </summary>
	/// <param name="dictionary"></param>
	/// <param name="theme"></param>
	public static void SetTheme(ResourceDictionary dictionary, string theme)
	{
		foreach (var key in dictionary.Keys)
		{
			if (key is string s && ThemeRegex().Match(s) is Match match && match.Success)
			{
				dictionary[key] = dictionary[theme + match.Groups[1].Value];
			}
		}
	}

	/// <summary>
	/// Set the theme of the application.
	/// </summary>
	/// <param name="theme"></param>
	public static void SetTheme(string theme)
	{
		var mergeDictionaries = Application.Current?.Resources.MergedDictionaries;
		if (mergeDictionaries is not null)
		{
			foreach (var dictionary in mergeDictionaries)
			{
				if (dictionary is IThemeDictionary)
				{
					SetTheme(dictionary, theme);
				}
			}
		}
	}

	/// <summary>
	/// Set the theme of the application.
	/// </summary>
	/// <param name="theme"></param>
	public static void SetTheme(AppTheme theme)
	{
		SetTheme(theme.ToString());
	}
}
