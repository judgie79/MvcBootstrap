using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MvcBootstrap.Controls
{
	public class Icon
	{
		private const string ICON_PATTERN = @"<i class=""icon-{0}{1}""></i>";
		
		private Icons _icon;
		private Color _color;

		public Icon(Icons icon)
			: this(icon, Color.Black)
		{
		}

		public Icon(Icons icon, Color color)
		{
			_icon = icon;
			_color = color;
		}

		public MvcHtmlString Render()
		{
			return new MvcHtmlString(string.Format(ICON_PATTERN, 
				_icon.ToString().ToLowerInvariant().Replace("_", "-"), 
				_color == Color.Black ? string.Empty : " icon-" + _color.ToString().ToLowerInvariant()));
		}

		public enum Color
		{
			Black,
			White
		}

		public enum Icons
		{
			Glass,
			Music,
			Search,
			Envelope,
			Heart,
			Star,
			Star_empty,
			User,
			Film,
			Th_large,
			Th,
			Th_list,
			Ok,
			Remove,
			Zoom_in,
			Zoom_out,
			Off,
			Signal,
			Cog,
			Trash,
			Home,
			File,
			Time,
			Road,
			Download_alt,
			Download,
			Upload,
			Inbox,
			Play_circle,
			Repeat,
			Refresh,
			List_alt,
			Lock,
			Flag,
			Headphones,
			Volume_off,
			Volume_down,
			Volume_up,
			Qrcode,
			Barcode,
			Tag,
			Tags,
			Book,
			Bookmark,
			Print,
			Camera,
			Font,
			Bold,
			Italic,
			Text_height,
			Text_width,
			Align_left,
			Align_center,
			Align_right,
			Align_justify,
			List,
			Indent_left,
			Indent_right,
			Facetime_video,
			Picture,
			Pencil,
			Map_marker,
			Adjust,
			Tint,
			Edit,
			Share,
			Check,
			Move,
			Step_backward,
			Fast_backward,
			Backward,
			Play,
			Pause,
			Stop,
			Forward,
			Fast_forward,
			Step_forward,
			Eject,
			Chevron_left,
			Chevron_right,
			Plus_sign,
			Minus_sign,
			Remove_sign,
			Ok_sign,
			Question_sign,
			Info_sign,
			Screenshot,
			Remove_circle,
			Ok_circle,
			Ban_circle,
			Arrow_left,
			Arrow_right,
			Arrow_up,
			Arrow_down,
			Share_alt,
			Resize_full,
			Resize_small,
			Plus,
			Minus,
			Asterisk,
			Exclamation_sign,
			Gift,
			Leaf,
			Fire,
			Eye_open,
			Eye_close,
			Warning_sign,
			Plane,
			Calendar,
			Random,
			Comment,
			Magnet,
			Chevron_up,
			Chevron_down,
			Retweet,
			Shopping_cart,
			Folder_close,
			Folder_open,
			Resize_vertical,
			Resize_horizontal,
			Hdd,
			Bullhorn,
			Bell,
			Certificate,
			Thumbs_up,
			Thumbs_down,
			Hand_right,
			Hand_left,
			Hand_up,
			Hand_down,
			Circle_arrow_right,
			Circle_arrow_left,
			Circle_arrow_up,
			Circle_arrow_down,
			Globe,
			Wrench,
			Tasks,
			Filter,
			Briefcase,
			Fullscreen
		}
	}
}
