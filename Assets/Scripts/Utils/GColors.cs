using UnityEngine;

public enum GColorPallet
{
	INK_YELLOW,
	INK_BLUE,
	DEBUG_RAY_GREEN,
	CANNON_RED,
}

public enum GBrushChannel
{
	INK_YELLOW = 0,
	INK_BLUE = 1,
}

public class GColors
{
	string splatoon_yellow = "#FFF021";
	string splatoon_purple = "#761AFF";
	string splatoon_blue = "#4422FF";

	public static Color GetColor(GColorPallet colorId)
	{
		switch (colorId)
		{
			case GColorPallet.INK_YELLOW:
				return Color.yellow;

			case GColorPallet.INK_BLUE:
				return Color.blue;

			case GColorPallet.DEBUG_RAY_GREEN:
				return Color.green;

			case GColorPallet.CANNON_RED:
				return Color.red;

			default:
				return Color.gray;
		}
	}

	public static GBrushChannel GetBrushChannelFromColor(GColorPallet colorId)
	{
		switch (colorId)
		{
			case GColorPallet.INK_BLUE:
				return GBrushChannel.INK_BLUE;

			default:
				return GBrushChannel.INK_YELLOW;
		}
	}
};
